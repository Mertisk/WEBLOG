﻿using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {

        List<Message> GetInBoxListByWriter(string p);

    }

}
