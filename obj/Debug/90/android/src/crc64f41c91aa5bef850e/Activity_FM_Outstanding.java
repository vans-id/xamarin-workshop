package crc64f41c91aa5bef850e;


public class Activity_FM_Outstanding
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("AppPOS.FM_Outstanding.Activity_FM_Outstanding, AppPOS", Activity_FM_Outstanding.class, __md_methods);
	}


	public Activity_FM_Outstanding ()
	{
		super ();
		if (getClass () == Activity_FM_Outstanding.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_Outstanding.Activity_FM_Outstanding, AppPOS", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
