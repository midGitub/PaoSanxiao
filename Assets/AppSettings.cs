
#region Copyright (c) 2015 KEngine / Kelly <http://github.com/mr-kelly>, All rights reserved.

// KEngine - Asset Bundle framework for Unity3D
// ===================================
// 
// Author:  Kelly
// Email: 23110388@qq.com
// Github: https://github.com/mr-kelly/KEngine
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3.0 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library.

#endregion

// This file is auto generated by SettingModuleEditor.cs!
// Don't manipulate me!
// Default Template for KEngine!

using System.Collections;
using System.Collections.Generic;
using KEngine;
using KEngine.Modules;
using TableML;
namespace AppSettings
{
	/// <summary>
    /// All settings list here, so you can reload all settings manully from the list.
	/// </summary>
    public partial class SettingsManager
    {
        private static IReloadableSettings[] _settingsList;
        public static IReloadableSettings[] SettingsList
        {
            get
            {
                if (_settingsList == null)
                {
                    _settingsList = new IReloadableSettings[]
                    { 
                        ActorConfigSettings._instance,
                        EffectTableSettings._instance,
                        ErrorCodeSettings._instance,
                        GameConfigSettings._instance,
                    };
                }
                return _settingsList;
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("KEngine/Settings/Try Reload All Settings Code")]
#endif
	    public static void AllSettingsReload()
	    {
	        for (var i = 0; i < SettingsList.Length; i++)
	        {
	            var settings = SettingsList[i];
                if (settings.Count > 0 // if never reload, ignore
#if UNITY_EDITOR
                    || !UnityEditor.EditorApplication.isPlaying // in editor and not playing, force load!
#endif
                    )
                {
                    settings.ReloadAll();
                }

	        }
	    }

    }


	/// <summary>
	/// Auto Generate for Tab File: "ActorConfig.k"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class ActorConfigSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "ActorConfig.k"
        };
        internal static ActorConfigSettings _instance = new ActorConfigSettings();
        Dictionary<int, ActorConfigSetting> _dict = new Dictionary<int, ActorConfigSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private ActorConfigSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static ActorConfigSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: ActorConfig, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : ActorConfig, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: ActorConfig
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = ActorConfigSetting.ParsePrimaryKey(row);
                        ActorConfigSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new ActorConfigSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: ActorConfig
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: ActorConfig
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: ActorConfig
        /// </summary>
        public static ActorConfigSetting Get(int primaryKey)
        {
            ActorConfigSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "ActorConfig.k"
    /// Singleton class for less memory use
	/// </summary>
	public partial class ActorConfigSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public int Id { get; private set;}
        
        /// <summary>
        /// Name/名字
        /// </summary>
        public string Name { get; private set;}
        
        /// <summary>
        /// Des/描述
        /// </summary>
        public string Des { get; private set;}
        

        internal ActorConfigSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_int(row.Values[0], ""); 
            Name = row.Get_string(row.Values[1], ""); 
            Des = row.Get_string(row.Values[2], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static int ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_int(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "EffectTable.k"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class EffectTableSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "EffectTable.k"
        };
        internal static EffectTableSettings _instance = new EffectTableSettings();
        Dictionary<int, EffectTableSetting> _dict = new Dictionary<int, EffectTableSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private EffectTableSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static EffectTableSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: EffectTable, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : EffectTable, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: EffectTable
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = EffectTableSetting.ParsePrimaryKey(row);
                        EffectTableSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new EffectTableSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: EffectTable
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: EffectTable
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: EffectTable
        /// </summary>
        public static EffectTableSetting Get(int primaryKey)
        {
            EffectTableSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "EffectTable.k"
    /// Singleton class for less memory use
	/// </summary>
	public partial class EffectTableSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public int Id { get; private set;}
        
        /// <summary>
        /// Name/名字
        /// </summary>
        public string Name { get; private set;}
        
        /// <summary>
        /// Des/描述
        /// </summary>
        public string Des { get; private set;}
        

        internal EffectTableSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_int(row.Values[0], ""); 
            Name = row.Get_string(row.Values[1], ""); 
            Des = row.Get_string(row.Values[2], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static int ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_int(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "ErrorCode.k"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class ErrorCodeSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "ErrorCode.k"
        };
        internal static ErrorCodeSettings _instance = new ErrorCodeSettings();
        Dictionary<string, ErrorCodeSetting> _dict = new Dictionary<string, ErrorCodeSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private ErrorCodeSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static ErrorCodeSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: ErrorCode, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : ErrorCode, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: ErrorCode
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = ErrorCodeSetting.ParsePrimaryKey(row);
                        ErrorCodeSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new ErrorCodeSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: ErrorCode
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: ErrorCode
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: ErrorCode
        /// </summary>
        public static ErrorCodeSetting Get(string primaryKey)
        {
            ErrorCodeSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "ErrorCode.k"
    /// Singleton class for less memory use
	/// </summary>
	public partial class ErrorCodeSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// Name/错误信息
        /// </summary>
        public string Name { get; private set;}
        
        /// <summary>
        /// Text/提示信息
        /// </summary>
        public string Text { get; private set;}
        

        internal ErrorCodeSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            Name = row.Get_string(row.Values[1], ""); 
            Text = row.Get_string(row.Values[2], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "GameConfig/#Base.k", "GameConfig/#TSV.k"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class GameConfigSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "GameConfig/#Base.k", "GameConfig/#TSV.k"
        };
        internal static GameConfigSettings _instance = new GameConfigSettings();
        Dictionary<string, GameConfigSetting> _dict = new Dictionary<string, GameConfigSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private GameConfigSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static GameConfigSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: GameConfig, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : GameConfig, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: GameConfig
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = GameConfigSetting.ParsePrimaryKey(row);
                        GameConfigSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new GameConfigSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: GameConfig
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: GameConfig
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: GameConfig
        /// </summary>
        public static GameConfigSetting Get(string primaryKey)
        {
            GameConfigSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "GameConfig/#Base.k", "GameConfig/#TSV.k"
    /// Singleton class for less memory use
	/// </summary>
	public partial class GameConfigSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// Name/名字
        /// </summary>
        public string Value { get; private set;}
        

        internal GameConfigSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            Value = row.Get_string(row.Values[1], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}
 
}