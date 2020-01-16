using ObjCRuntime;

namespace WechatSDK.WXApiObject
{
	public enum WXErrCode
	{
		Success = 0,
		ErrCodeCommon = -1,
		ErrCodeUserCancel = -2,
		ErrCodeSentFail = -3,
		ErrCodeAuthDeny = -4,
		ErrCodeUnsupport = -5
	}

	public enum WXScene : uint
	{
		Session = 0,
		Timeline = 1,
		Favorite = 2,
		SpecifiedSession = 3
	}

	public enum WXAPISupport : uint
	{
		WXAPISupportSession = 0
	}

	public enum WXBizProfileType : uint
	{
		Normal = 0,
		Device = 1
	}

	[Native]
	public enum WXMiniProgramType : ulong
	{
		Release = 0,
		Test = 1,
		Preview = 2
	}

	public enum WXMPWebviewType : uint
	{
		WXMPWebviewType_Ad = 0
	}

	[Native]
	public enum WXLogLevel : long
	{
		Normal = 0,
		Detail = 1
	}
}
