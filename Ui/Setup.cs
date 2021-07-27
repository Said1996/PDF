using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ui
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.FieldBinding.Plugin>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.MethodBinding.Plugin>();
        }
    }
}
