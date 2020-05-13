﻿using AutoMapper;
using System.Collections.Generic;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.Services.App
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;
        public LogService(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private LogViewModel Add(LogViewModel entity)
        {
            var log = _repo.Add(_mapper.Map<Log>(entity));
            return _mapper.Map<LogViewModel>(log);
        }

        public LogViewModel Add(LogViewModel entity, string token)
        {
            entity.Token = token;
            return Add(entity);
        }

        public bool Delete(int entityId)
        {
            bool resultDelete = false;
            var log = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            
            if (log != null)
            {
                log.Deleted = true;
                resultDelete = _repo.Update(log);
            }

            return resultDelete;
        }

        public LogViewModel Get(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<LogViewModel>(log);
        }

        public bool Update(LogViewModel entity)
        {
            bool resultUpdate = false;
            var log = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (log != null)
            {
                resultUpdate = _repo.Update(_mapper.Map<Log>(entity));
            }
           
            return resultUpdate;
        }

        public List<LogViewModel> SelectAll()
        {
            var logs = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<LogViewModel>>(logs);
        }
    }
}