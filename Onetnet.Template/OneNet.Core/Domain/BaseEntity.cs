using System.Collections.Generic;

namespace OneNet.Core.Domain
{
    public class BaseEntity
    {
        private IList<BaseEvent> _events = new List<BaseEvent>();

        public void CleanEvent()
        {
            _events.Clear();
        }

        public void Raise()
        {
            
        }
    }
}