package crc64384fc3993c9794e4;


public class FFAnimatedDrawable
	extends crc64384fc3993c9794e4.SelfDisposingBitmapDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", FFAnimatedDrawable.class, __md_methods);
	}


	public FFAnimatedDrawable ()
	{
		super ();
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "", this, new java.lang.Object[] {  });
		}
	}


	public FFAnimatedDrawable (android.content.res.Resources p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "Android.Content.Res.Resources, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, android.graphics.Bitmap p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "Android.Content.Res.Resources, Mono.Android:Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, java.io.InputStream p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "Android.Content.Res.Resources, Mono.Android:System.IO.Stream, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public FFAnimatedDrawable (android.content.res.Resources p0, java.lang.String p1)
	{
		super (p0, p1);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "Android.Content.Res.Resources, Mono.Android:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public FFAnimatedDrawable (android.graphics.Bitmap p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "Android.Graphics.Bitmap, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public FFAnimatedDrawable (java.io.InputStream p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "System.IO.Stream, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


	public FFAnimatedDrawable (java.lang.String p0)
	{
		super (p0);
		if (getClass () == FFAnimatedDrawable.class) {
			mono.android.TypeManager.Activate ("FFImageLoading.Drawables.FFAnimatedDrawable, FFImageLoading.Compat", "System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}

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
