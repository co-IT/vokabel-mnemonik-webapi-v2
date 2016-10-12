using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace VokabelMnemonikApi.Hypermedia
{
    public class GenericFormatter<T, THypermedia> : MediaTypeFormatter where T : class, new()
    {
        private readonly ISerializeHyperMedia<T, THypermedia> _hyperMediaSerializer;

        public GenericFormatter(ISerializeHyperMedia<T, THypermedia> hyperMediaSerializer)
        {
            _hyperMediaSerializer = hyperMediaSerializer;
            SupportedMediaTypes.Clear();
            SupportedMediaTypes.Add(_hyperMediaSerializer.MediaTypeHeaderValue);
        }

        public override bool CanReadType(Type type)
        {
            return typeof(T) == type;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == null)
                return false;

            if (type == typeof(T))
                return true;

            if (IsListOfType(type))
                return true;

            return false;
        }

        private static bool IsListOfType(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeOfGeneric = type.GenericTypeArguments[0];
            var typeOfGenericIsRequestedType = typeof(T).IsAssignableFrom(typeOfGeneric);

            return typeOfGenericIsRequestedType;
        }


        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream,
            HttpContent content, TransportContext transportContext)
        {
            var valueAsHypermedia = _hyperMediaSerializer.Mapper.FromEntities(value as IEnumerable<T>);

            return _hyperMediaSerializer.Formatter.WriteToStreamAsync(type, valueAsHypermedia,
                writeStream, content, transportContext);
        }
    }
}