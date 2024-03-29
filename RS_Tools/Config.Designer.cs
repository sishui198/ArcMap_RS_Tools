//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RS_Tools {
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Editor;
    using ESRI.ArcGIS.esriSystem;
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.Desktop.AddIns;
    
    
    /// <summary>
    /// A class for looking up declarative information in the associated configuration xml file (.esriaddinx).
    /// </summary>
    internal static class ThisAddIn {
        
        internal static string Name {
            get {
                return "RS_Tools";
            }
        }
        
        internal static string AddInID {
            get {
                return "{a1f80a4e-7369-4e14-9978-bee8e7697732}";
            }
        }
        
        internal static string Company {
            get {
                return "Woolpert Inc.";
            }
        }
        
        internal static string Version {
            get {
                return "1.6.2";
            }
        }
        
        internal static string Description {
            get {
                return "Tools used to enhance performance and utilities to increase producitivy in ArcGIS" +
                    " Desktop";
            }
        }
        
        internal static string Author {
            get {
                return "Chris Stayte";
            }
        }
        
        internal static string Date {
            get {
                return "5/30/2019";
            }
        }
        
        internal static ESRI.ArcGIS.esriSystem.UID ToUID(this System.String id) {
            ESRI.ArcGIS.esriSystem.UID uid = new ESRI.ArcGIS.esriSystem.UIDClass();
            uid.Value = id;
            return uid;
        }
        
        /// <summary>
        /// A class for looking up Add-in id strings declared in the associated configuration xml file (.esriaddinx).
        /// </summary>
        internal class IDs {
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_FileTileLoader_Button', the id declared for Add-in Button class 'RS_Tools.Tools.FileTileLoader.FileTileLoader_Button'
            /// </summary>
            internal static string RS_Tools_Tools_FileTileLoader_FileTileLoader_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_FileTileLoader_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_FileTileOpener_Tool', the id declared for Add-in Tool class 'RS_Tools.Tools.FileTileOpener.FileTileOpener_Tool'
            /// </summary>
            internal static string RS_Tools_Tools_FileTileOpener_FileTileOpener_Tool {
                get {
                    return "Woolpert_Inc_RS_Tools_FileTileOpener_Tool";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_FileTileOpenerSettings_Button', the id declared for Add-in Button class 'RS_Tools.Tools.FileTileOpener.FileTileOpenerSettings_Button'
            /// </summary>
            internal static string RS_Tools_Tools_FileTileOpener_FileTileOpenerSettings_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_FileTileOpenerSettings_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Inspector_Launcher', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.Inspector_Launcher'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_Inspector_Launcher {
                get {
                    return "Woolpert_Inc_RS_Tools_Inspector_Launcher";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_OKNext', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.OKNext'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_OKNext {
                get {
                    return "Woolpert_Inc_RS_Tools_OKNext";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_OKNextScale', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.OKNextScale'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_OKNextScale {
                get {
                    return "Woolpert_Inc_RS_Tools_OKNextScale";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_OkayStay', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.OkayStay'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_OkayStay {
                get {
                    return "Woolpert_Inc_RS_Tools_OkayStay";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_DeleteNext', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.DeleteNext'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_DeleteNext {
                get {
                    return "Woolpert_Inc_RS_Tools_DeleteNext";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_InspectorSorter_Launcher', the id declared for Add-in Button class 'RS_Tools.Tools.Inspector.InspectorSorter_Launcher'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_InspectorSorter_Launcher {
                get {
                    return "Woolpert_Inc_RS_Tools_InspectorSorter_Launcher";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_AutoSaveSettings', the id declared for Add-in Button class 'RS_Tools.Tools.AutoSave.AutoSaveSettings'
            /// </summary>
            internal static string RS_Tools_Tools_AutoSave_AutoSaveSettings {
                get {
                    return "Woolpert_Inc_RS_Tools_AutoSaveSettings";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Sidekick_Button', the id declared for Add-in Button class 'RS_Tools.Tools.Sidekick.Sidekick_Button'
            /// </summary>
            internal static string RS_Tools_Tools_Sidekick_Sidekick_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_Sidekick_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_DomainAppointerLauncher', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.DomainAppointerLauncher'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_DomainAppointerLauncher {
                get {
                    return "Woolpert_Inc_RS_Tools_DomainAppointerLauncher";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_Null', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_Null'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_Null {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_Null";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_00', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_00'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_00 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_00";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_01', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_01'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_01 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_01";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_02', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_02'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_02 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_02";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_03', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_03'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_03 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_03";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_04', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_04'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_04 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_04";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_05', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_05'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_05 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_05";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_06', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_06'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_06 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_06";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_07', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_07'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_07 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_07";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_08', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_08'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_08 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_08";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_09', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_09'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_09 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_09";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_10', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_10'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_10 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_10";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_11', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_11'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_11 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_11";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_12', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_12'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_12 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_12";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_13', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_13'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_13 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_13";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_14', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_14'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_14 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_14";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_15', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_15'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_15 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_15";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_16', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_16'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_16 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_16";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_17', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_17'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_17 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_17";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_18', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_18'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_18 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_18";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Domain_19', the id declared for Add-in Button class 'RS_Tools.Tools.DomainAppointer.Domain_19'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_Domain_19 {
                get {
                    return "Woolpert_Inc_RS_Tools_Domain_19";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_SurfaceGenerator_Launcher', the id declared for Add-in Button class 'RS_Tools.Tools.SurfaceGenerator.SurfaceGenerator_Launcher'
            /// </summary>
            internal static string RS_Tools_Tools_SurfaceGenerator_SurfaceGenerator_Launcher {
                get {
                    return "Woolpert_Inc_RS_Tools_SurfaceGenerator_Launcher";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_NotificationButton', the id declared for Add-in Button class 'RS_Tools.Tools.Sandbox.NotificationButton'
            /// </summary>
            internal static string RS_Tools_Tools_Sandbox_NotificationButton {
                get {
                    return "Woolpert_Inc_RS_Tools_NotificationButton";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_CollapseAllLayers', the id declared for Add-in Button class 'RS_Tools.Tools.CollapseAllLayers.CollapseAllLayers'
            /// </summary>
            internal static string RS_Tools_Tools_CollapseAllLayers_CollapseAllLayers {
                get {
                    return "Woolpert_Inc_RS_Tools_CollapseAllLayers";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_FileTileCloner_Button', the id declared for Add-in Button class 'RS_Tools.Tools.FileTileCloner.FileTileCloner_Button'
            /// </summary>
            internal static string RS_Tools_Tools_FileTileCloner_FileTileCloner_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_FileTileCloner_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Homesite_Tool', the id declared for Add-in Tool class 'RS_Tools.Tools.Homesite.Homesite_Tool'
            /// </summary>
            internal static string RS_Tools_Tools_Homesite_Homesite_Tool {
                get {
                    return "Woolpert_Inc_RS_Tools_Homesite_Tool";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_HomesiteSettings_Button', the id declared for Add-in Button class 'RS_Tools.Tools.Homesite.HomesiteSettings_Button'
            /// </summary>
            internal static string RS_Tools_Tools_Homesite_HomesiteSettings_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_HomesiteSettings_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_RS_Tools_Loader', the id declared for Add-in Button class 'RS_Tools.Tools.RS_Tools_Settings.RS_Tools_Loader'
            /// </summary>
            internal static string RS_Tools_Tools_RS_Tools_Settings_RS_Tools_Loader {
                get {
                    return "Woolpert_Inc_RS_Tools_RS_Tools_Loader";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_PrepLASData_Button', the id declared for Add-in Button class 'RS_Tools.Tools.EcogUtilites.PrepLASData_Button'
            /// </summary>
            internal static string RS_Tools_Tools_EcogUtilites_PrepLASData_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_PrepLASData_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_FileTileExister_Button', the id declared for Add-in Button class 'RS_Tools.Tools.FileTileExister.FileTileExister_Button'
            /// </summary>
            internal static string RS_Tools_Tools_FileTileExister_FileTileExister_Button {
                get {
                    return "Woolpert_Inc_RS_Tools_FileTileExister_Button";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_Inspector', the id declared for Add-in DockableWindow class 'RS_Tools.Tools.Inspector.Inspector+AddinImpl'
            /// </summary>
            internal static string RS_Tools_Tools_Inspector_Inspector {
                get {
                    return "Woolpert_Inc_RS_Tools_Inspector";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_DomainAppointer', the id declared for Add-in DockableWindow class 'RS_Tools.Tools.DomainAppointer.DomainAppointer+AddinImpl'
            /// </summary>
            internal static string RS_Tools_Tools_DomainAppointer_DomainAppointer {
                get {
                    return "Woolpert_Inc_RS_Tools_DomainAppointer";
                }
            }
            
            /// <summary>
            /// Returns 'Woolpert_Inc_RS_Tools_RS_Tools_Settings', the id declared for Add-in Extension class 'RS_Tools.Tools.RS_Tools_Settings.RS_Tools_Settings'
            /// </summary>
            internal static string RS_Tools_Tools_RS_Tools_Settings_RS_Tools_Settings {
                get {
                    return "Woolpert_Inc_RS_Tools_RS_Tools_Settings";
                }
            }
        }
    }
    
internal static class ArcMap
{
  private static IApplication s_app = null;
  private static IDocumentEvents_Event s_docEvent;

  public static IApplication Application
  {
    get
    {
      if (s_app == null)
      {
        s_app = Internal.AddInStartupObject.GetHook<IMxApplication>() as IApplication;
        if (s_app == null)
        {
          IEditor editorHost = Internal.AddInStartupObject.GetHook<IEditor>();
          if (editorHost != null)
            s_app = editorHost.Parent;
        }
      }
      return s_app;
    }
  }

  public static IMxDocument Document
  {
    get
    {
      if (Application != null)
        return Application.Document as IMxDocument;

      return null;
    }
  }
  public static IMxApplication ThisApplication
  {
    get { return Application as IMxApplication; }
  }
  public static IDockableWindowManager DockableWindowManager
  {
    get { return Application as IDockableWindowManager; }
  }
  public static IDocumentEvents_Event Events
  {
    get
    {
      s_docEvent = Document as IDocumentEvents_Event;
      return s_docEvent;
    }
  }
  public static IEditor Editor
  {
    get
    {
      UID editorUID = new UID();
      editorUID.Value = "esriEditor.Editor";
      return Application.FindExtensionByCLSID(editorUID) as IEditor;
    }
  }
}

namespace Internal
{
  [StartupObjectAttribute()]
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public sealed partial class AddInStartupObject : AddInEntryPoint
  {
    private static AddInStartupObject _sAddInHostManager;
    private List<object> m_addinHooks = null;

    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
    public AddInStartupObject()
    {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override bool Initialize(object hook)
    {
      bool createSingleton = _sAddInHostManager == null;
      if (createSingleton)
      {
        _sAddInHostManager = this;
        m_addinHooks = new List<object>();
        m_addinHooks.Add(hook);
      }
      else if (!_sAddInHostManager.m_addinHooks.Contains(hook))
        _sAddInHostManager.m_addinHooks.Add(hook);

      return createSingleton;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
    protected override void Shutdown()
    {
      _sAddInHostManager = null;
      m_addinHooks = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
    internal static T GetHook<T>() where T : class
    {
      if (_sAddInHostManager != null)
      {
        foreach (object o in _sAddInHostManager.m_addinHooks)
        {
          if (o is T)
            return o as T;
        }
      }

      return null;
    }

    // Expose this instance of Add-in class externally
    public static AddInStartupObject GetThis()
    {
      return _sAddInHostManager;
    }
  }
}
}
