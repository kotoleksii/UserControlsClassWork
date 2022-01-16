using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace UserControls
{
    public partial class SmartUploader : System.Web.UI.UserControl
    {
        public string UploadFolder { get; set; } = "SmartUploadFiles";
        
        public bool AutoRename { get; set; } = false;

        public string CssClass { get; set; }

        public AcceptedFileTypes AllowedFileTypes { get; set; } = AcceptedFileTypes.Any;

        protected string FileFilterAttribute;

        protected string[] documentMIMETypes =
        {
            ".doc",
            "docx",
            "application/msword",
            "application / vnd.openxmlformats - officedocument.wordprocessingml.document",
            "application/vnd.oasis.opendocument.presentation",
            "application/vnd.oasis.opendocument.spreadsheet",
            "application/vnd.oasis.opendocument.text",
            "application/pdf",
            "application/vnd.ms-powerpoint",
            "application/vnd.openxmlformats-officedocument.presentationml.presentation",
            "application/rtf",
            "text/plain",
            "application/vnd.ms-excel",
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        };

        public delegate void FileUploadedEvenHandler(object sender, FileUploadedArgs e);

        public event FileUploadedEvenHandler FileUploaded;

        public virtual void OnUploadComplete(FileUploadedArgs e)
        {
            // якщо є підписники (звнішні слухачі заходу)
            if(FileUploaded != null)
            {
                // публікуємо захід для підписників
                FileUploaded(this, e);
            }
        }

        public enum AcceptedFileTypes {
            Any,
            Audio,
            Video,
            Images,
            Documents
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            switch (AllowedFileTypes)
            {
                case AcceptedFileTypes.Any:
                    break;
                case AcceptedFileTypes.Audio:
                    FileFilterAttribute = "audio/*";
                    break;
                case AcceptedFileTypes.Video:
                    FileFilterAttribute = "video/*";
                    break;
                case AcceptedFileTypes.Images:
                    FileFilterAttribute = "image/*";
                    break;
                case AcceptedFileTypes.Documents:
                    FileFilterAttribute = String.Join(", ", documentMIMETypes);
                    break;
                default:
                    FileFilterAttribute = "*/*";
                    break;
            }
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(fileUpload.HasFile)
            {
                string UploadFolderPath = Server.MapPath($"~/{UploadFolder}");
                string UploadedFileName = fileUpload.PostedFile.FileName;

                if(!Directory.Exists(UploadFolderPath))
                {
                    Directory.CreateDirectory(UploadFolderPath);
                }

                if (AutoRename)
                {
                    UploadedFileName = Path.GetFileNameWithoutExtension(UploadedFileName)
                        + "_"
                        + DateTime.Now.Ticks.ToString()
                        + Path.GetExtension(UploadedFileName);
                }

                fileUpload.SaveAs(Path.Combine(UploadFolderPath, UploadedFileName));

                OnUploadComplete(new FileUploadedArgs()
                {
                    FileName = UploadedFileName,
                    Path = UploadFolderPath
                });

                lblUploadResult.Text = "Upload complete";
            }
            else
            {
                lblUploadResult.Text = "Please select file to upload";
            }
        }
    }

    public class FileUploadedArgs : EventArgs
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}