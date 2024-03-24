using AutoMapper;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.DataAccess.Abstract;

namespace PiDataEmailApp.Business.Concrete
{
    public class EpostaGonderimDetayManager:IEpostaGonderimDetayService
    {
        private readonly IEpostaGonderimDetayDal _epostaGonderimDetayDal;
        private readonly IMapper _mapper;

        public EpostaGonderimDetayManager(IEpostaGonderimDetayDal epostaGonderimDetayDal,
            IMapper mapper)
        {
            _epostaGonderimDetayDal = epostaGonderimDetayDal;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<EpostaGonderimDetayModel>>> GetAll()
        {
            var response = await _epostaGonderimDetayDal.GetAll();
            var result = _mapper.Map<List<EpostaGonderimDetayModel>>(response);
            return await ResponseModel<List<EpostaGonderimDetayModel>>.SuccessAsync(result, 200);
        }

        public async Task<ResponseModel<List<EpostaGonderimDetayWithIncludeModel>>> GetAllWithIncludesAsync()
        {
            var response = await _epostaGonderimDetayDal.GetAllWithIncludesAsync();
            var result = _mapper.Map<List<EpostaGonderimDetayWithIncludeModel>>(response);
            return await ResponseModel<List<EpostaGonderimDetayWithIncludeModel>>.SuccessAsync(result, 200);
        }

        public ResponseModel<EpostaGonderimDetayModel> GetById(int id)
        {
            var response = _epostaGonderimDetayDal.GetById(id);
            var result = _mapper.Map<EpostaGonderimDetayModel>(response);
            return ResponseModel<EpostaGonderimDetayModel>.Success(result, 200);
        }

        public Task Delete(int id)
        {
            return _epostaGonderimDetayDal.Delete(id);
        }
    }
}
