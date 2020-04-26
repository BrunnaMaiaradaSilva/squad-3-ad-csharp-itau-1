﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.UseCase.DTO;

namespace TryLog.UseCase.Interfaces
{
    public interface ILogUC
    {
        void Add(LogDTO entity);
        LogDTO Get(int entityId);
        LogDTO Find(int entityId);
        List<LogDTO> FindAll(int entityId);
        void SaveOrUpdate(LogDTO entity);
        void Delete(int entityId);
        List<LogDTO> SelectAll();
    }
}