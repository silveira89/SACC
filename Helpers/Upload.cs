namespace SACC.Helpers {
    public static class Upload {

        public static string SalvarImagem(IFormFile anexo, string _filePath) {
            var nome = anexo.FileName;

            var filePath = _filePath + "\\images";
            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }

            using (var stream = System.IO.File.Create(filePath + "\\" + nome)) {
                anexo.CopyToAsync(stream);
            }

            return nome;
        }

        public static string SalvarPdf(IFormFile anexo, string _filePath) {
            var nome = anexo.FileName;

            var filePath = _filePath + "\\pdf";
            if (!Directory.Exists(filePath)) {
                Directory.CreateDirectory(filePath);
            }

            using (var stream = System.IO.File.Create(filePath + "\\" + nome)) {
                anexo.CopyToAsync(stream);
            }

            return nome;
        }
    }
}
