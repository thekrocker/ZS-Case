using System;

namespace Statics
{
    public static class StaticEvents
    {
        public static Action<int> OnLevelChanged;
        public static Action OnPreGameStarted;
        public static Action OnTappedToPlay;
        public static Action OnArrivedFinish;
        public static Action OnNextButtonClicked;
    }
}

