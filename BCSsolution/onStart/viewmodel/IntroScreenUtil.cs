using BCSsolution.onStart.view;
using System;

namespace BCSsolution.onStart.viewmodel
{
    public static class IntroScreenUtil
    {
        private static IntroScreen mSplash;
        public static IntroScreen Splash { get { return mSplash;} set { mSplash = value;}}
        public static void ShowSplash()
        {
            if (mSplash != null)
            {
                mSplash.Show();
            }
        }

        public static void CloseSplash()
        {
            if (mSplash != null)
            {
                mSplash.Close();
                if (mSplash is IDisposable)
                    (mSplash as IDisposable).Dispose();
            }
        }
    }
}
