using FDS.DbLogger.PostgreSQL.Application.Interfaces;
using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.DbLogger.PostgreSQL.Application.Services;

public class AuditLogServiceFactory : IAuditLogServiceFactory
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogServiceFactory(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public IAuditLogService Create(string contextName)
    {
        return new AuditLogService(_auditLogRepository, contextName);
    }
}
