namespace EventSystem
{
    public static class EventsInstance
    {
        private static Events _events;
        public static Events Events => _events ??= new Events();
    }
}