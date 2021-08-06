using Base.Models;
using Base.Services;

namespace HrAdm.Services
{
    public class UserEdit : XpEdit
    {
        public UserEdit(string ctrl) : base(ctrl) { }

        override public EditDto GetDto()
        {
            return new EditDto
            {
				Table = "dbo.[User]",
                PkeyFid = "Id",
                Col4 = null,
                Items = new [] 
				{
					new EitemDto { Fid = "Id" },
					new EitemDto { Fid = "Account" },
					new EitemDto { Fid = "Name" },
					new EitemDto { Fid = "Pwd" },
					new EitemDto { Fid = "DeptId" },
					new EitemDto { Fid = "Status" },
                },
                Childs = new EditDto[]
                {
                    new EditDto
                    {
                        Table = "dbo.XpUserRole",
                        PkeyFid = "Id",
                        FkeyFid = "UserId",
                        Col4 = null,
                        Items = new [] 
						{
							new EitemDto { Fid = "Id" },
							new EitemDto { Fid = "UserId" },
							new EitemDto { Fid = "RoleId", Required = true },
                        },
                    },
                },
            };
        }

    } //class
}
