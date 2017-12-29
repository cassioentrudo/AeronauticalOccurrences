using System.IO;
using CSharpTest.Net.Serialization;

namespace AeronauticalOccurrences
{
    /// <summary>
    /// Serializador e deserializador de dados.
    /// Necessário para o funcionamento da árvore B+.
    /// </summary>
    /// <typeparam name="T">Classe a ser serializada.</typeparam>
    /// <seealso cref="CSharpTest.Net.Serialization.ISerializer{T}" />
    public class ProtoNetSerializer<T> : ISerializer<T>
    {
        public T ReadFrom(Stream stream)
        {
            return ProtoBuf.Serializer.DeserializeWithLengthPrefix<T>(stream, ProtoBuf.PrefixStyle.Base128);
        }
        public void WriteTo(T value, Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix<T>(stream, value, ProtoBuf.PrefixStyle.Base128);
        }
    }
}
