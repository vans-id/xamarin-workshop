package crc64380a24bb3933efa9;


public class ClassDataparser
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
		mono.android.Runtime.register ("AppPOS.FM_Transaction.ClassTransaction.ClassDataparser, AppPOS", ClassDataparser.class, __md_methods);
	}


	public ClassDataparser ()
	{
		super ();
		if (getClass () == ClassDataparser.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_Transaction.ClassTransaction.ClassDataparser, AppPOS", "", this, new java.lang.Object[] {  });
	}

	public ClassDataparser (android.content.Context p0, android.app.FragmentManager p1, android.app.FragmentTransaction p2, android.widget.ListView p3, android.widget.TextView p4, android.widget.ImageView p5, android.widget.Button p6)
	{
		super ();
		if (getClass () == ClassDataparser.class)
			mono.android.TypeManager.Activate ("AppPOS.FM_Transaction.ClassTransaction.ClassDataparser, AppPOS", "Android.Content.Context, Mono.Android:Android.App.FragmentManager, Mono.Android:Android.App.FragmentTransaction, Mono.Android:Android.Widget.ListView, Mono.Android:Android.Widget.TextView, Mono.Android:Android.Widget.ImageView, Mono.Android:Android.Widget.Button, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5, p6 });
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
