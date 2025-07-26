using Core.Exceptions.Types;

namespace Core.Exceptions.Handlers
{
    public abstract class ExceptionHandler // abstract bir class olacak
    {

        //işleyen metotların hepsini kapsayan ana bir metottur. hepsi burada birleştirilir
        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                BusinessException businessException => HandleException(businessException), //bbusinessexception türünde exception varsa businessexceptionı çağır
                _ => HandleException(exception)  //_ ile işin sonunda return edilecek alanı belirtir. bunların hiçbiri ise exceptionı çağır
            };
        
        //işleyecek metotlar
        protected abstract Task HandleException(BusinessException businessException); // buiness çalışıyorsa bu metot handle edecek
        protected abstract Task HandleException(Exception exception);
         

        //not found, authantication, autrozation yapıları için handle metotları yazılır.
    }
}
