namespace backend.Helpers
{
    public static class Utilities
    {
        public static byte[]? ConvertIFormFileToBytes(IFormFile file)
        {
            using (var ms = new MemoryStream())

                if (file.Length > 0)
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }

            return null;
        }
    }
}
