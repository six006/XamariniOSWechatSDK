﻿// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
// to the project by right-clicking (or Control-clicking) the folder containing this source
// file and clicking "Add files..." and then simply select the native library (or libraries)
// that you want to bind.
//
// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
// native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
// architectures that the native library supports and fills in that information for you,
// however, it cannot auto-detect any Frameworks or other system libraries that the
// native library may depend on, so you'll need to fill in that information yourself.
//
// Once you've done that, you're ready to move on to binding the API...
//
//
// Here is where you'd define your API definition for the native Objective-C library.
//
// For example, to bind the following Objective-C class:
//
//     @interface Widget : NSObject {
//     }
//
// The C# binding would look like this:
//
//     [BaseType (typeof (NSObject))]
//     interface Widget {
//     }
//
// To bind Objective-C properties, such as:
//
//     @property (nonatomic, readwrite, assign) CGPoint center;
//
// You would add a property definition in the C# interface like so:
//
//     [Export ("center")]
//     CGPoint Center { get; set; }
//
// To bind an Objective-C method, such as:
//
//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
//
// You would add a method definition to the C# interface like so:
//
//     [Export ("doSomething:atIndex:")]
//     void DoSomething (NSObject object, int index);
//
// Objective-C "constructors" such as:
//
//     -(id)initWithElmo:(ElmoMuppet *)elmo;
//
// Can be bound as:
//
//     [Export ("initWithElmo:")]
//     IntPtr Constructor (ElmoMuppet elmo);
//
// For more information, see https://aka.ms/ios-binding

using Foundation;
using ObjCRuntime;
using UIKit;

namespace WechatSDK.WXApiObject
{
	// typedef void (^WXLogBolock)(NSString * _Nonnull);
	delegate void WXLogBolock(string arg0);

	// @interface BaseReq : NSObject
	[BaseType(typeof(NSObject))]
	interface BaseReq
	{
		// @property (assign, nonatomic) int type;
		[Export("type")]
		int Type { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull openID;
		[Export("openID")]
		string OpenID { get; set; }
	}

	// @interface BaseResp : NSObject
	[BaseType(typeof(NSObject))]
	interface BaseResp
	{
		// @property (assign, nonatomic) int errCode;
		[Export("errCode")]
		int ErrCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull errStr;
		[Export("errStr")]
		string ErrStr { get; set; }

		// @property (assign, nonatomic) int type;
		[Export("type")]
		int Type { get; set; }
	}

	// @interface PayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface PayReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull partnerId;
		[Export("partnerId")]
		string PartnerId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull prepayId;
		[Export("prepayId")]
		string PrepayId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nonceStr;
		[Export("nonceStr")]
		string NonceStr { get; set; }

		// @property (assign, nonatomic) UInt32 timeStamp;
		[Export("timeStamp")]
		uint TimeStamp { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull package;
		[Export("package")]
		string Package { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull sign;
		[Export("sign")]
		string Sign { get; set; }
	}

	// @interface PayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface PayResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull returnKey;
		[Export("returnKey")]
		string ReturnKey { get; set; }
	}

	// @interface WXOfflinePayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOfflinePayReq
	{
	}

	// @interface WXOfflinePayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOfflinePayResp
	{
	}

	// @interface WXNontaxPayReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXNontaxPayReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull urlString;
		[Export("urlString")]
		string UrlString { get; set; }
	}

	// @interface WXNontaxPayResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXNontaxPayResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull wxOrderId;
		[Export("wxOrderId")]
		string WxOrderId { get; set; }
	}

	// @interface WXPayInsuranceReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXPayInsuranceReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull urlString;
		[Export("urlString")]
		string UrlString { get; set; }
	}

	// @interface WXPayInsuranceResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXPayInsuranceResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull wxOrderId;
		[Export("wxOrderId")]
		string WxOrderId { get; set; }
	}

	// @interface SendAuthReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface SendAuthReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull scope;
		[Export("scope")]
		string Scope { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull state;
		[Export("state")]
		string State { get; set; }
	}

	// @interface SendAuthResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface SendAuthResp
	{
		// @property (copy, nonatomic) NSString * _Nullable code;
		[NullAllowed, Export("code")]
		string Code { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export("state")]
		string State { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable lang;
		[NullAllowed, Export("lang")]
		string Lang { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable country;
		[NullAllowed, Export("country")]
		string Country { get; set; }
	}

	// @interface SendMessageToWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface SendMessageToWXReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull text;
		[Export("text")]
		string Text { get; set; }

		// @property (nonatomic, strong) WXMediaMessage * _Nonnull message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (assign, nonatomic) BOOL bText;
		[Export("bText")]
		bool BText { get; set; }

		// @property (assign, nonatomic) int scene;
		[Export("scene")]
		int Scene { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable toUserOpenId;
		[NullAllowed, Export("toUserOpenId")]
		string ToUserOpenId { get; set; }
	}

	// @interface SendMessageToWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface SendMessageToWXResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull lang;
		[Export("lang")]
		string Lang { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull country;
		[Export("country")]
		string Country { get; set; }
	}

	// @interface GetMessageFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface GetMessageFromWXReq
	{
		// @property (nonatomic, strong) NSString * _Nonnull lang;
		[Export("lang", ArgumentSemantic.Strong)]
		string Lang { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull country;
		[Export("country", ArgumentSemantic.Strong)]
		string Country { get; set; }
	}

	// @interface GetMessageFromWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface GetMessageFromWXResp
	{
		// @property (nonatomic, strong) NSString * _Nonnull text;
		[Export("text", ArgumentSemantic.Strong)]
		string Text { get; set; }

		// @property (nonatomic, strong) WXMediaMessage * _Nonnull message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (assign, nonatomic) BOOL bText;
		[Export("bText")]
		bool BText { get; set; }
	}

	// @interface ShowMessageFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface ShowMessageFromWXReq
	{
		// @property (nonatomic, strong) WXMediaMessage * _Nonnull message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull lang;
		[Export("lang")]
		string Lang { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull country;
		[Export("country")]
		string Country { get; set; }
	}

	// @interface ShowMessageFromWXResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface ShowMessageFromWXResp
	{
	}

	// @interface LaunchFromWXReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface LaunchFromWXReq
	{
		// @property (nonatomic, strong) WXMediaMessage * _Nonnull message;
		[Export("message", ArgumentSemantic.Strong)]
		WXMediaMessage Message { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull lang;
		[Export("lang")]
		string Lang { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull country;
		[Export("country")]
		string Country { get; set; }
	}

	// @interface OpenWebviewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface OpenWebviewReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export("url")]
		string Url { get; set; }
	}

	// @interface OpenWebviewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface OpenWebviewResp
	{
	}

	// @interface WXOpenBusinessWebViewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOpenBusinessWebViewReq
	{
		// @property (assign, nonatomic) UInt32 businessType;
		[Export("businessType")]
		uint BusinessType { get; set; }

		// @property (nonatomic, strong) NSDictionary * _Nullable queryInfoDic;
		[NullAllowed, Export("queryInfoDic", ArgumentSemantic.Strong)]
		NSDictionary QueryInfoDic { get; set; }
	}

	// @interface WXOpenBusinessWebViewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOpenBusinessWebViewResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull result;
		[Export("result")]
		string Result { get; set; }

		// @property (assign, nonatomic) UInt32 businessType;
		[Export("businessType")]
		uint BusinessType { get; set; }
	}

	// @interface OpenRankListReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface OpenRankListReq
	{
	}

	// @interface OpenRankListResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface OpenRankListResp
	{
	}

	// @interface WXCardItem : NSObject
	[BaseType(typeof(NSObject))]
	interface WXCardItem
	{
		// @property (copy, nonatomic) NSString * _Nonnull cardId;
		[Export("cardId")]
		string CardId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extMsg;
		[NullAllowed, Export("extMsg")]
		string ExtMsg { get; set; }

		// @property (assign, nonatomic) UInt32 cardState;
		[Export("cardState")]
		uint CardState { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull encryptCode;
		[Export("encryptCode")]
		string EncryptCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull appID;
		[Export("appID")]
		string AppID { get; set; }
	}

	// @interface WXInvoiceItem : NSObject
	[BaseType(typeof(NSObject))]
	interface WXInvoiceItem
	{
		// @property (copy, nonatomic) NSString * _Nonnull cardId;
		[Export("cardId")]
		string CardId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extMsg;
		[NullAllowed, Export("extMsg")]
		string ExtMsg { get; set; }

		// @property (assign, nonatomic) UInt32 cardState;
		[Export("cardState")]
		uint CardState { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull encryptCode;
		[Export("encryptCode")]
		string EncryptCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull appID;
		[Export("appID")]
		string AppID { get; set; }
	}

	// @interface AddCardToWXCardPackageReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface AddCardToWXCardPackageReq
	{
		// @property (nonatomic, strong) NSArray * _Nonnull cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] CardAry { get; set; }
	}

	// @interface AddCardToWXCardPackageResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface AddCardToWXCardPackageResp
	{
		// @property (nonatomic, strong) NSArray * _Nonnull cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] CardAry { get; set; }
	}

	// @interface WXChooseCardReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXChooseCardReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull appID;
		[Export("appID")]
		string AppID { get; set; }

		// @property (assign, nonatomic) UInt32 shopID;
		[Export("shopID")]
		uint ShopID { get; set; }

		// @property (assign, nonatomic) UInt32 canMultiSelect;
		[Export("canMultiSelect")]
		uint CanMultiSelect { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull cardType;
		[Export("cardType")]
		string CardType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull cardTpID;
		[Export("cardTpID")]
		string CardTpID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull signType;
		[Export("signType")]
		string SignType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull cardSign;
		[Export("cardSign")]
		string CardSign { get; set; }

		// @property (assign, nonatomic) UInt32 timeStamp;
		[Export("timeStamp")]
		uint TimeStamp { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nonceStr;
		[Export("nonceStr")]
		string NonceStr { get; set; }
	}

	// @interface WXChooseCardResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXChooseCardResp
	{
		// @property (nonatomic, strong) NSArray * _Nonnull cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] CardAry { get; set; }
	}

	// @interface WXChooseInvoiceReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXChooseInvoiceReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull appID;
		[Export("appID")]
		string AppID { get; set; }

		// @property (assign, nonatomic) UInt32 shopID;
		[Export("shopID")]
		uint ShopID { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull signType;
		[Export("signType")]
		string SignType { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull cardSign;
		[Export("cardSign")]
		string CardSign { get; set; }

		// @property (assign, nonatomic) UInt32 timeStamp;
		[Export("timeStamp")]
		uint TimeStamp { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nonceStr;
		[Export("nonceStr")]
		string NonceStr { get; set; }
	}

	// @interface WXChooseInvoiceResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXChooseInvoiceResp
	{
		// @property (nonatomic, strong) NSArray * _Nonnull cardAry;
		[Export("cardAry", ArgumentSemantic.Strong)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] CardAry { get; set; }
	}

	// @interface WXSubscribeMsgReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXSubscribeMsgReq
	{
		// @property (assign, nonatomic) UInt32 scene;
		[Export("scene")]
		uint Scene { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull templateId;
		[Export("templateId")]
		string TemplateId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable reserved;
		[NullAllowed, Export("reserved")]
		string Reserved { get; set; }
	}

	// @interface WXSubscribeMsgResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXSubscribeMsgResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull templateId;
		[Export("templateId")]
		string TemplateId { get; set; }

		// @property (assign, nonatomic) UInt32 scene;
		[Export("scene")]
		uint Scene { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull action;
		[Export("action")]
		string Action { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull reserved;
		[Export("reserved")]
		string Reserved { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable openId;
		[NullAllowed, Export("openId")]
		string OpenId { get; set; }
	}

	// @interface WXSubscribeMiniProgramMsgReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXSubscribeMiniProgramMsgReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull miniProgramAppid;
		[Export("miniProgramAppid")]
		string MiniProgramAppid { get; set; }
	}

	// @interface WXSubscribeMiniProgramMsgResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXSubscribeMiniProgramMsgResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull openId;
		[Export("openId")]
		string OpenId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull unionId;
		[Export("unionId")]
		string UnionId { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull nickName;
		[Export("nickName")]
		string NickName { get; set; }
	}

	// @interface WXInvoiceAuthInsertReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXInvoiceAuthInsertReq
	{
		// @property (copy, nonatomic) NSString * _Nonnull urlString;
		[Export("urlString")]
		string UrlString { get; set; }
	}

	// @interface WXInvoiceAuthInsertResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXInvoiceAuthInsertResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull wxOrderId;
		[Export("wxOrderId")]
		string WxOrderId { get; set; }
	}

	// @interface WXMediaMessage : NSObject
	[BaseType(typeof(NSObject))]
	interface WXMediaMessage
	{
		// +(WXMediaMessage * _Nonnull)message;
		[Static]
		[Export("message")]
		//[Verify(MethodToProperty)]
		WXMediaMessage Message { get; }

		// @property (copy, nonatomic) NSString * _Nonnull title;
		[Export("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; set; }

		// @property (nonatomic, strong) NSData * _Nullable thumbData;
		[NullAllowed, Export("thumbData", ArgumentSemantic.Strong)]
		NSData ThumbData { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable mediaTagName;
		[NullAllowed, Export("mediaTagName")]
		string MediaTagName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable messageExt;
		[NullAllowed, Export("messageExt")]
		string MessageExt { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable messageAction;
		[NullAllowed, Export("messageAction")]
		string MessageAction { get; set; }

		// @property (nonatomic, strong) id _Nonnull mediaObject;
		[Export("mediaObject", ArgumentSemantic.Strong)]
		NSObject MediaObject { get; set; }

		// -(void)setThumbImage:(UIImage * _Nonnull)image;
		[Export("setThumbImage:")]
		void SetThumbImage(UIImage image);
	}

	// @interface WXImageObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXImageObject
	{
		// +(WXImageObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXImageObject Object { get; }

		// @property (nonatomic, strong) NSData * _Nonnull imageData;
		[Export("imageData", ArgumentSemantic.Strong)]
		NSData ImageData { get; set; }
	}

	// @interface WXMusicObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXMusicObject
	{
		// +(WXMusicObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXMusicObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull musicUrl;
		[Export("musicUrl")]
		string MusicUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull musicLowBandUrl;
		[Export("musicLowBandUrl")]
		string MusicLowBandUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull musicDataUrl;
		[Export("musicDataUrl")]
		string MusicDataUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull musicLowBandDataUrl;
		[Export("musicLowBandDataUrl")]
		string MusicLowBandDataUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull songAlbumUrl;
		[Export("songAlbumUrl")]
		string SongAlbumUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable songLyric;
		[NullAllowed, Export("songLyric")]
		string SongLyric { get; set; }
	}

	// @interface WXVideoObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXVideoObject
	{
		// +(WXVideoObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXVideoObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull videoUrl;
		[Export("videoUrl")]
		string VideoUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull videoLowBandUrl;
		[Export("videoLowBandUrl")]
		string VideoLowBandUrl { get; set; }
	}

	// @interface WXWebpageObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXWebpageObject
	{
		// +(WXWebpageObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXWebpageObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull webpageUrl;
		[Export("webpageUrl")]
		string WebpageUrl { get; set; }
	}

	// @interface WXAppExtendObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXAppExtendObject
	{
		// +(WXAppExtendObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXAppExtendObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull url;
		[Export("url")]
		string Url { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extInfo;
		[NullAllowed, Export("extInfo")]
		string ExtInfo { get; set; }

		// @property (nonatomic, strong) NSData * _Nullable fileData;
		[NullAllowed, Export("fileData", ArgumentSemantic.Strong)]
		NSData FileData { get; set; }
	}

	// @interface WXEmoticonObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXEmoticonObject
	{
		// +(WXEmoticonObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXEmoticonObject Object { get; }

		// @property (nonatomic, strong) NSData * _Nonnull emoticonData;
		[Export("emoticonData", ArgumentSemantic.Strong)]
		NSData EmoticonData { get; set; }
	}

	// @interface WXFileObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXFileObject
	{
		// +(WXFileObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXFileObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull fileExtension;
		[Export("fileExtension")]
		string FileExtension { get; set; }

		// @property (nonatomic, strong) NSData * _Nonnull fileData;
		[Export("fileData", ArgumentSemantic.Strong)]
		NSData FileData { get; set; }
	}

	// @interface WXLocationObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXLocationObject
	{
		// +(WXLocationObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXLocationObject Object { get; }

		// @property (assign, nonatomic) double lng;
		[Export("lng")]
		double Lng { get; set; }

		// @property (assign, nonatomic) double lat;
		[Export("lat")]
		double Lat { get; set; }
	}

	// @interface WXTextObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXTextObject
	{
		// +(WXTextObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXTextObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull contentText;
		[Export("contentText")]
		string ContentText { get; set; }
	}

	// @interface WXMiniProgramObject : NSObject
	[BaseType(typeof(NSObject))]
	interface WXMiniProgramObject
	{
		// +(WXMiniProgramObject * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXMiniProgramObject Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull webpageUrl;
		[Export("webpageUrl")]
		string WebpageUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull userName;
		[Export("userName")]
		string UserName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export("path")]
		string Path { get; set; }

		// @property (nonatomic, strong) NSData * _Nullable hdImageData;
		[NullAllowed, Export("hdImageData", ArgumentSemantic.Strong)]
		NSData HdImageData { get; set; }

		// @property (assign, nonatomic) BOOL withShareTicket;
		[Export("withShareTicket")]
		bool WithShareTicket { get; set; }

		// @property (assign, nonatomic) WXMiniProgramType miniProgramType;
		[Export("miniProgramType", ArgumentSemantic.Assign)]
		WXMiniProgramType MiniProgramType { get; set; }

		// @property (assign, nonatomic) BOOL disableForward;
		[Export("disableForward")]
		bool DisableForward { get; set; }
	}

	// @interface WXLaunchMiniProgramReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXLaunchMiniProgramReq
	{
		// +(WXLaunchMiniProgramReq * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXLaunchMiniProgramReq Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull userName;
		[Export("userName")]
		string UserName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable path;
		[NullAllowed, Export("path")]
		string Path { get; set; }

		// @property (assign, nonatomic) WXMiniProgramType miniProgramType;
		[Export("miniProgramType", ArgumentSemantic.Assign)]
		WXMiniProgramType MiniProgramType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extMsg;
		[NullAllowed, Export("extMsg")]
		string ExtMsg { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable extDic;
		[NullAllowed, Export("extDic", ArgumentSemantic.Copy)]
		NSDictionary ExtDic { get; set; }
	}

	// @interface WXLaunchMiniProgramResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXLaunchMiniProgramResp
	{
		// @property (copy, nonatomic) NSString * _Nullable extMsg;
		[NullAllowed, Export("extMsg")]
		string ExtMsg { get; set; }
	}

	// @interface WXOpenBusinessViewReq : BaseReq
	[BaseType(typeof(BaseReq))]
	interface WXOpenBusinessViewReq
	{
		// +(WXOpenBusinessViewReq * _Nonnull)object;
		[Static]
		[Export("object")]
		//[Verify(MethodToProperty)]
		WXOpenBusinessViewReq Object { get; }

		// @property (copy, nonatomic) NSString * _Nonnull businessType;
		[Export("businessType")]
		string BusinessType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable query;
		[NullAllowed, Export("query")]
		string Query { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extInfo;
		[NullAllowed, Export("extInfo")]
		string ExtInfo { get; set; }

		// @property (nonatomic, strong) NSData * _Nullable extData;
		[NullAllowed, Export("extData", ArgumentSemantic.Strong)]
		NSData ExtData { get; set; }
	}

	// @interface WXOpenBusinessViewResp : BaseResp
	[BaseType(typeof(BaseResp))]
	interface WXOpenBusinessViewResp
	{
		// @property (copy, nonatomic) NSString * _Nonnull businessType;
		[Export("businessType")]
		string BusinessType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extMsg;
		[NullAllowed, Export("extMsg")]
		string ExtMsg { get; set; }
	}
}
