using System;
using ObjCRuntime;

[assembly: LinkWith ("libWeChatSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
