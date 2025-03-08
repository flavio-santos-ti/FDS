using FDS.DbLogger.PostgreSQL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.DbLogger.PostgreSQL.Application.Interfaces;

public interface IAuditLogServiceFactory
{
    IAuditLogService Create(string contextName);
}
