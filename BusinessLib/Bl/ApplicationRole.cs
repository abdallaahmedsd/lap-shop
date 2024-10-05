using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Bl
{
	public class ApplicationRole:IdentityRole
	{

		public Dictionary<string, object> RolePremssions { get; set; } = new Dictionary<string, object>();

	}
}
