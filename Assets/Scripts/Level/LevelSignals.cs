using System;

namespace Level
{
    public static class LevelSignals 
    {
        public static Action onGetNextLevel;
        public static Action onLoadLevel;
        public static Action onClearLevel;
    }
}