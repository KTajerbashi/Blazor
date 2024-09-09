﻿using CleanArchitectureBlazor.Core.CoreBase.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitectureBlazor.Core.Domains.Security;

[Table("UserRole", Schema = "Security"), Description("نقش کاربر")]
public class UserRoleEntity : IdentityUserRole<long>, IEntity {}
