using Nancy;
using Nancy.ViewEngines;
using Nancy.ErrorHandling;


namespace Nancy.Demo2
{

    /// <summary>
    /// �Զ���http status������
    /// </summary>
    public class MyStatusHandler : IStatusCodeHandler
    {
        private IViewRenderer viewRenderer;

        public MyStatusHandler(IViewRenderer viewRenderer)
        {
            this.viewRenderer = viewRenderer;
        }

        /// <summary>
        /// ��ǰ״̬�Ƿ���Ҫ�Լ�����
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            //return false;
            return (statusCode == HttpStatusCode.NotFound //�磺404״̬�루�Ҳ�����ҳ�����Լ�����
                //|| statusCode == HttpStatusCode.ServiceUnavailable
                //|| statusCode == HttpStatusCode.InternalServerError
                );
        }

        /// <summary>
        /// ���崦�����
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="context"></param>
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = viewRenderer.RenderView(context, "Status/404",null); //ָ��ר�õ�cshtml�ļ�
            response.StatusCode = statusCode == HttpStatusCode.NotFound ? HttpStatusCode.OK : statusCode;
            context.Response = response;
        }
    }


}