using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservation.Core.Helpers
{
    public class CustomFromFile : IFormFile
    {
        #region Private properties

        private readonly byte[] _fileBytes;
        private readonly string _file;

        #endregion

        #region Public properties

        public Guid Id { get; }
        public string ContentType => throw new System.NotImplementedException();

        public string ContentDisposition => throw new System.NotImplementedException();

        public IHeaderDictionary Headers => throw new System.NotImplementedException();

        public long Length => _fileBytes.LongLength;

        public string FileName => _file;

        public string Name=> Path.GetFileNameWithoutExtension(_file);

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomFromFile(byte[] fileBytes, string file, Guid id )
        {
            _fileBytes = fileBytes;
            _file = file;
            Id = id;
        }

        public CustomFromFile(byte[] fileBytes, string file) : this(fileBytes, file, Guid.Empty) { }

        #endregion

        #region Public methods

        public void CopyTo(Stream target)
        {
            target.Write(_fileBytes, 0, _fileBytes.Length);
        }

        public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            await target.WriteAsync(_fileBytes, 0, _fileBytes.Length, cancellationToken);
        }

        public Stream OpenReadStream()
        {
            return new MemoryStream(_fileBytes);
        }

        #endregion
    }
}