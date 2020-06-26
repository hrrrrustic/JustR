using System;
using System.Collections.Generic;

namespace JustR.NotificationService
{
    //TODO : Бд?
    public class ConnectionManager
    {
        private static readonly Dictionary<Guid, HashSet<String>> _connections = new Dictionary<Guid, HashSet<String>>();

        public void AddConnection(Guid userId, String connectionId)
        {
            lock (_connections)
            {
                if (_connections.TryGetValue(userId, out HashSet<String> userConnections))
                {
                    userConnections.Add(connectionId);
                    return;
                }

                _connections.Add(userId, new HashSet<String>{connectionId});
            }
        }

        public void RemoveConnection(Guid userId, String connectionId)
        {
            lock (_connections)
            {
                 if (_connections.TryGetValue(userId, out HashSet<String> userConnections))
                     if (userConnections.Count == 1)
                         _connections.Remove(userId);
                     else
                         userConnections.Remove(connectionId);
            }
        }

        public HashSet<String> GetUserConnections(Guid userId)
         {
            lock (_connections)
            {
                return _connections.TryGetValue(userId, out var connections) ? connections : new HashSet<String>();
            }
        }
    }
}