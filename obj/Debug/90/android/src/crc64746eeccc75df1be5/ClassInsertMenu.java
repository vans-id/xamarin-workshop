package crc64746eeccc75df1be5;


public class ClassInsertMenu
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AppPOS.FM_MasterMenu.ClassMasterMenu.ClassInsertMenu, AppPOS", ClassInsertMenu.class, __md_methods);
	}


	public ClassInsertMenu ()
	{
		super ();
		if (getClass () == ClassInsertMenu.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_MasterMenu.ClassMasterMenu.ClassInsertMenu, AppPOS", "", this, new java.lang.Object[] {  });
	}

	public ClassInsertMenu (android.app.Activity p0, android.widget.EditText p1, android.widget.EditText p2, android.widget.EditText p3, android.widget.EditText p4, android.widget.Button p5)
	{
		super ();
		if (getClass () == ClassInsertMenu.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_MasterMenu.ClassMasterMenu.ClassInsertMenu, AppPOS", "Android.App.Activity, Mono.Android:Android.Widget.EditText, Mono.Android:Android.Widget.EditText, Mono.Android:Android.Widget.EditText, Mono.Android:Android.Widget.EditText, Mono.Android:Android.Widget.Button, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
