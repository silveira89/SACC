namespace SACC.Helpers {
    public class Validation {

        public static bool ValidaImagem(IFormFile fileImage) {
            switch (fileImage.ContentType) {
                case "image/jpeg":
                    return true;
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/png":
                    return true;
                default:
                    return false;
                    break;
            }
        }

        public static bool ValidaPdf(IFormFile filePdf) {
            switch (filePdf.ContentType) {
                case "application/pdf":
                    return true;
                default:
                    return false;
                    break;
            }
        }
    }
}
