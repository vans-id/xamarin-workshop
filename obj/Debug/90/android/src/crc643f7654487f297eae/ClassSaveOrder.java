package crc643f7654487f297eae;


public class ClassSaveOrder
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AppPOS.FM_Outstanding.ClassOutstanding.ClassSaveOrder, AppPOS", ClassSaveOrder.class, __md_methods);
	}


	public ClassSaveOrder ()
	{
		super ();
		if (getClass () == ClassSaveOrder.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_Outstanding.ClassOutstanding.ClassSaveOrder, AppPOS", "", this, new java.lang.Object[] {  });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);

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
