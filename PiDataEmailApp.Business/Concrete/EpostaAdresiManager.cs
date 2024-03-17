using AutoMapper;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Concrete;

public class EpostaAdresiManager:IEpostaAdresiService
{
    private readonly IEpostaAdresiDal _epostaAdresiDal;
    private readonly IMapper _mapper;
    
    public EpostaAdresiManager(IEpostaAdresiDal epostaAdresiDal,
        IMapper mapper)
    {
        _epostaAdresiDal = epostaAdresiDal;
        _mapper = mapper;
    }
    
    public async Task<ResponseModel<List<EpostaAdresiModel>>> GetAll()
    {
        var response=await _epostaAdresiDal.GetAll();
        var result=_mapper.Map<List<EpostaAdresiModel>>(response);
        return await ResponseModel<List<EpostaAdresiModel>>.SuccessAsync(result,200);
    }

    public ResponseModel<EpostaAdresiModel> GetById(int id)
    {
        var response = _epostaAdresiDal.GetById(id);
        var result = _mapper.Map<EpostaAdresiModel>(response);
        return ResponseModel<EpostaAdresiModel>.Success(result, 200);
    }

    public ResponseModel<EpostaAdresiModel> Create(EpostaAdresiModel model)
    {
        var response = _mapper.Map<EpostaAdresi>(model);
        var result=_epostaAdresiDal.Add(response);
        return ResponseModel<EpostaAdresiModel>.Success(model, 200);
    }

    public ResponseModel<NoContentModel> CreateList(List<EpostaAdresiModel> model)
    {
        var response = _mapper.Map<List<EpostaAdresi>>(model);
        _epostaAdresiDal.AddList(response);
        return ResponseModel<NoContentModel>.Success(204);
    }

    public ResponseModel<EpostaAdresiModel> Update(int id, EpostaAdresiModel model)
    {
        var response = _mapper.Map<EpostaAdresi>(model);
        _epostaAdresiDal.Update(id, response);
        return ResponseModel<EpostaAdresiModel>.Success(model, 200);
    }

    public Task Delete(int id)
    {
        return _epostaAdresiDal.Delete(id);
    }
}

