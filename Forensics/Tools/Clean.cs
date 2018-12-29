using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forensics.Tools
{
    public class Clean
    {
        public void CleanTable(string tableName)
        {
            SQLiteHelper inst = new SQLiteHelper();
            /*inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%?xml%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%<msg>%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%<mmreader>%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%sysmsg%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%http%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%wxid%' AND Content NOT Like '%Att/%'");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content=''");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where SendTime=''");*/
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%?xml%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%<msg>%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%<mmreader>%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%sysmsg%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%http%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content Like '%wxid%' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where Content='' AND TargetID='" + StateInfo.CaseID + "' ");
            inst.ExecuteNonQuery("Update " + tableName + " Set IsDeleted='1' Where SendTime='' AND TargetID='" + StateInfo.CaseID + "' ");
        }
    }
}
