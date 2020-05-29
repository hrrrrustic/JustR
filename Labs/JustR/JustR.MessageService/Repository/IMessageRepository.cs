﻿using System;
using System.Collections.Generic;
using JustR.Models.Entity;

namespace JustR.MessageService.Repository
{
    public interface IMessageRepository
    {
        List<Message> ReadMessages(Guid dialogId, Int32 count, Int32 offset = 0);
        Message CreateMessage(Message message);
    }
}