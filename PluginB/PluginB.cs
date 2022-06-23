﻿using PluginLoader.Interface;

namespace PluginB
{
    public class PluginB : IPlugin, IPluginLoader, IPluginAPI, ICommands
    {
        public string ID => $"com.github.1160706050.{Name}";
        public string Name => "PluginB";
        public string? Description => "描述";
        public string[]? Author => new string[] { "Bunny_i" };
        public Version Version => new(1, 0, 0);
        public bool IsPublicPlugin => true;

        #region API接口实现

        public string[] PluginIDs => new string[] { "com.github.1160706050.PluginA" };
        public PluginDictionary Plugins { get; set; } = new PluginDictionary();

        #endregion

        #region ICommands 命令接口实现
        public ICommand[] Commands { get; set; } = new ICommand[] { new CommandB() };

        #endregion

        #region IPlugin 接口插件正式初始化和关闭 

        public void Initialize()
        {
            Console.WriteLine($"[{Name}] 插件被初始化");
            var a = Plugins.GetPlugin<PluginA.PluginA>();
            a?.Test(Name);
        }
        public void Close() { Console.WriteLine($"[{Name}] 插件被关闭"); }

        #endregion

        #region IPluginLoader 实现内容，一般用于插件加载器加载通知

        public void OnLoad() { Console.WriteLine($"[{Name}] 插件被加载"); }
        public void OnReLoad() { Console.WriteLine($"[{Name}] 插件被重载"); }
        public void OnUnLoad() { Console.WriteLine($"[{Name}] 插件被卸载"); }

        #endregion

    }

}