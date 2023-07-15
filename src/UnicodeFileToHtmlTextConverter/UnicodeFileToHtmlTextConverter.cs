using System.IO;
using System.Text;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public interface IFileReader
    {
        string[] ReadAllLines(string path);
    }

    public interface IHtmlEncoder
    {
        string HtmlEncode(string value, bool isLastLine = false);
    }

    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string _fullFilenameWithPath;
        private IFileReader _fileReader;
        private IHtmlEncoder _htmlEncoder;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            _fileReader = new FileReader();
            _htmlEncoder = new HtmlEncoder();
            StringBuilder htmlBuilder = new StringBuilder();
            string html = string.Empty;
            string[] lines = _fileReader.ReadAllLines(_fullFilenameWithPath);
            for (var i = 0; i < lines.Length; i++)
            {
                if (i == lines.Length - 1)
                {
                    html += _htmlEncoder.HtmlEncode(lines[i], true);
                }
                else
                {
                    html += _htmlEncoder.HtmlEncode(lines[i]);
                }

            }


            return html;
        }
    }

    // Implementation of IFileReader using System.IO
    public class FileReader : IFileReader
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }

    // Implementation of IHtmlEncoder using System.Web
    public class HtmlEncoder : IHtmlEncoder
    {
        public string HtmlEncode(string value, bool isLastLine = false)
        {

            return HttpUtility.HtmlEncode(value) + (isLastLine ? "" : "<br />");
        }
    }
}
