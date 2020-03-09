using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class CarlaoException : Exception
    {
        //Aqui deveria haver um Task também??
        //Provavelmente iremos ter que fazer a Exception.
        public List<Error> Errors { get; private set; }

    public CarlaoException(List<Error> errors)
    {
        this.Errors = errors;
    }

    //Daqui pra baixo é apenas código que o proprio VS gera 
    //pra gente poder utilizar esta exceção 
    public CarlaoException(string message) : base(message) { }
    public CarlaoException(string message, Exception inner) : base(message, inner) { }
    protected CarlaoException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
    
}
