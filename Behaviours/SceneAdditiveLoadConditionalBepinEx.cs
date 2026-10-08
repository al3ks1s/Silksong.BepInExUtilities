using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BepInExUtilities.Behaviours
{

    [Serializable]
    [Tooltip("Extends the Scene Additional Load script to support bepinEx configs")]
    public class SceneAdditiveLoadConditionalBepinEx : SceneAdditiveLoadConditional
    {

        [SerializeField]
        public BepinExTest bepinTests;
        
        private void Awake()
        {
            
        }

        private new void OnEnable()
        {
            if (LoadInSequence && !sceneLoaded && TryTestLoad())
            {
                _additiveSceneLoads.Add(this);
            }
        }

        private new void Start()
        {
            if (LoadInSequence || sceneLoaded || !TryTestLoad())
            {
                return;
            }
            _additiveSceneLoads.Add(this);
            ApplySettings();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == SceneNameToLoad)
                {
                    sceneLoaded = true;
                    return;
                }
            }
            StartCoroutine(LoadRoutine(callEvent: true, this));
        }

        private new bool TryTestLoad()
        {
            bool flag = !tests.IsFulfilled || !BepinExTests();
            QuestTest[] array = questTests;
            foreach (QuestTest questTest in array)
            {
                if (!questTest.IsFulfilled)
                {
                    flag = true;
                    break;
                }
            }
            string entryGateName = GameManager.instance.entryGateName;
            if (!flag && doorWhiteList.Length != 0)
            {
                bool flag2 = false;
                string[] array2 = doorWhiteList;
                for (int i = 0; i < array2.Length; i++)
                {
                    if (array2[i].Equals(entryGateName))
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (!flag2)
                {
                    flag = true;
                }
            }
            if (!flag && doorBlackList.Length != 0)
            {
                string[] array2 = doorBlackList;
                for (int i = 0; i < array2.Length; i++)
                {
                    if (array2[i].Equals(entryGateName))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (!flag && otherLoaderBlacklist.Length != 0)
            {
                SceneAdditiveLoadConditional[] array3 = otherLoaderBlacklist;
                for (int i = 0; i < array3.Length; i++)
                {
                    if (array3[i].TryTestLoad())
                    {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
            {
                loadAlt = true;
            }
            return !string.IsNullOrEmpty(SceneNameToLoad);
        }

        private bool BepinExTests()
        {
            if (bepinTests != null)
            {
                return bepinTests.IsFulfilled;
            }

            return true;
        }
    }

    [Serializable]
    [Tooltip("Test group on bepinex configurations")]
    public class BepinExTest
    {
        public enum NumTestType
        {
            Equal,
            NotEqual,
            LessThan,
            MoreThan
        }
        public enum StringTestType
        {
            Equal,
            NotEqual,
            Contains,
            NotContains
        }


        [Serializable]
        public abstract class BepinTest
        {
            public virtual bool IsFulfilled
            {
                get { return false; }
            }
        }

        [Serializable]
        public class BepinTest<T> : BepinTest
        {
            public string KeyName;
            public string SectionName;
            public string BepinExPluginID;

            public T GetConfigValue()
            {
                return default;
            }
        }

        [Serializable]
        public class BepinTestBool : BepinTest<bool>
        {
            public bool ExpectedValue;

            public override bool IsFulfilled
            {
                get { return GetConfigValue() == ExpectedValue; }
            }
        }

        [Serializable]
        public class BepinTestInt : BepinTest<int>
        {
            public int ExpectedValue;
            public NumTestType testType;

            public override bool IsFulfilled
            {
                get
                {
                    var configValue = GetConfigValue();
                    switch (testType)
                    {
                        case NumTestType.Equal:
                            return configValue == ExpectedValue;
                        case NumTestType.NotEqual:
                            return configValue != ExpectedValue;
                        case NumTestType.LessThan:
                            return configValue < ExpectedValue;
                        case NumTestType.MoreThan:
                            return configValue > ExpectedValue;
                        default:
                            return false;
                    }
                }
            }
        }

        [Serializable]
        public class BepinTestFloat : BepinTest<float>
        {
            public float ExpectedValue;
            public NumTestType testType;

            public override bool IsFulfilled
            {
                get
                {
                    var configValue = GetConfigValue();
                    switch (testType)
                    {
                        case NumTestType.Equal:
                            return configValue == ExpectedValue;
                        case NumTestType.NotEqual:
                            return configValue != ExpectedValue;
                        case NumTestType.LessThan:
                            return configValue < ExpectedValue;
                        case NumTestType.MoreThan:
                            return configValue > ExpectedValue;
                        default:
                            return false;
                    }
                }
            }
        }
        [Serializable]
        public class BepinTestString : BepinTest<string>
        {
            public string ExpectedValue;
            public StringTestType testType;

            public override bool IsFulfilled
            {
                get
                {
                    var configValue = GetConfigValue();
                    switch (testType)
                    {
                        case StringTestType.Equal:
                            return configValue.Equals(ExpectedValue);
                        case StringTestType.NotEqual:
                            return !configValue.Equals(ExpectedValue);
                        case StringTestType.Contains:
                            return configValue.Contains(ExpectedValue);
                        case StringTestType.NotContains:
                            return !configValue.Contains(ExpectedValue);
                        default:
                            return false;
                    }
                }
            }
        }

        [Serializable]
        public class BepinTestGroup
        {

            public BepinTestGroup()
            { }

            [SerializeReference]
            public List<BepinTest> tests = new();

            public bool IsFulfilled
            {
                get
                {
                    if (tests == null) return true;
                    if (tests.Count == 0) return true;

                    return tests.All(t => t.IsFulfilled);
                }
            }
        }

        [SerializeField]
        public List<BepinTestGroup> tests = new();

        public bool IsFulfilled
        {
            get
            {
                if (tests == null) return true;
                if (tests.Count == 0) return true;

                return tests.Any(t => t.IsFulfilled);
            }
        }

        public BepinExTest()
        {

        }
    }
}
