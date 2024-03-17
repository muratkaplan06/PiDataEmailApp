using AutoMapper;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Concrete;

public class EpostaGonderimManager:IEpostaGonderimService
{
    private readonly IEpostaGonderimDal _epostaGonderimDal;
    private readonly IMapper _mapper;
    
    public EpostaGonderimManager(IEpostaGonderimDal epostaGonderimDal,
        IMapper mapper)
    {
        _epostaGonderimDal = epostaGonderimDal;
        _mapper = mapper;
    }
    public async Task<ResponseModel<List<EpostaGonderimModel>>> GetAll()
    {
        var response=await _epostaGonderimDal.GetAll();
        var result=_mapper.Map<List<EpostaGonderimModel>>(response);
        return await ResponseModel<List<EpostaGonderimModel>>.SuccessAsync(result,200);
        
    }

    public ResponseModel<EpostaGonderimModel> GetById(int id)
    {
        var response = _epostaGonderimDal.GetById(id);
        var result = _mapper.Map<EpostaGonderimModel>(response);
        return ResponseModel<EpostaGonderimModel>.Success(result, 200);
    }

    public ResponseModel<EpostaGonderimModel> Create(EpostaGonderimModel model)
    {
        var response = _mapper.Map<EpostaGonderim>(model);
        _epostaGonderimDal.Add(response);
        return ResponseModel<EpostaGonderimModel>.Success(model, 200);
    }

    public ResponseModel<NoContentModel> CreateList(List<EpostaGonderimModel> model)
    {
        var response = _mapper.Map<List<EpostaGonderim>>(model);
        _epostaGonderimDal.AddList(response);
        return ResponseModel<NoContentModel>.Success(204);
    }

    public ResponseModel<EpostaGonderimModel> Update(int id, EpostaGonderimModel model)
    {
        var response = _mapper.Map<EpostaGonderim>(model);
        _epostaGonderimDal.Update(id, response);
        return ResponseModel<EpostaGonderimModel>.Success(model, 200);
    }

    public Task Delete(int id)
    {
        return _epostaGonderimDal.Delete(id);
    }
}

