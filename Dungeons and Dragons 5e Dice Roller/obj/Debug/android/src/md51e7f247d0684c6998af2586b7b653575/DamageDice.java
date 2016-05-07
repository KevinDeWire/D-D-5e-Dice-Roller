package md51e7f247d0684c6998af2586b7b653575;


public class DamageDice
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
		mono.android.Runtime.register ("Dungeons_and_Dragons_5e_Dice_Roller.DamageDice, Dungeons and Dragons 5e Dice Roller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DamageDice.class, __md_methods);
	}


	public DamageDice () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DamageDice.class)
			mono.android.TypeManager.Activate ("Dungeons_and_Dragons_5e_Dice_Roller.DamageDice, Dungeons and Dragons 5e Dice Roller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
