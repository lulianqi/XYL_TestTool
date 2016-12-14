using MyCommonTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;

namespace TT_Huala_OrderPay.MyTool
{
    class MySsh
    {

        public static bool SshFileMkFullDir(SshTransferProtocolBase sshCp, string FilePath)
        {
            string[] files = FilePath.Split('/');
            List<string> nowFileList = files.ToList<string>();
            List<string> nextFileList = new List<string>();
            string outErrMes = null;
            if (files.Length < 2)
            {
                return false;
            }

            while (!SshFileMkDir(sshCp, StringHelper.StrListAdd(nowFileList, @"/"), out outErrMes))
            {
                if (outErrMes.Contains("No such file or directory"))
                {
                    nextFileList.Add(nowFileList[nowFileList.Count - 1]);
                    nowFileList.RemoveAt(nowFileList.Count - 1);
                }
                else
                {
                    return false;
                }
            }
            for (int i = nextFileList.Count - 1; i >= 0; i--)
            {
                nowFileList.Add(nextFileList[i]);
                if (!SshFileMkDir(sshCp, StringHelper.StrListAdd(nowFileList, @"/"), out outErrMes))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SshFileMkDir(SshTransferProtocolBase sshCp, string FilePath, out string errMes)
        {
            errMes = null;
            try
            {
                sshCp.Mkdir(FilePath);
                return true;
            }
            catch (Exception ex)
            {
                errMes = ex.Message;
                return false;
            }
        }
    }
}
