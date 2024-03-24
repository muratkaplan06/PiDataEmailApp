using AutoMapper;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.Entities;

namespace PiDataEmailApp.Business.Concrete;

public class KisiManager: IKisiService
{
    private readonly IKisiDal _kisiDal;
    private readonly IMapper _mapper;
    
    public KisiManager(IKisiDal kisiDal,
        IMapper mapper)
    {
        _kisiDal = kisiDal;
        _mapper = mapper;
    }
    
    public async Task<ResponseModel<List<Kisi>>> GetAll()
    {
        var response=await _kisiDal.GetAll();
        return await ResponseModel<List<Kisi>>.SuccessAsync(response,200);
    }

    public async Task<ResponseModel<List<Kisi>>> GetAllByFilter(string? cinsiyet, int? yasMin, int? yasMax)
    {
        var response = await _kisiDal.GetAllByFilter(cinsiyet, yasMin, yasMax);
        return await ResponseModel<List<Kisi>>.SuccessAsync(response, 200);
        
    }

    public ResponseModel<KisiModel> GetById(int id)
    {
        var response = _kisiDal.GetById(id);
        var result = _mapper.Map<KisiModel>(response);
        return ResponseModel<KisiModel>.Success(result, 200);
    }

    public ResponseModel<KisiModel> Create(KisiModel model)
    {
        var response = _mapper.Map<Kisi>(model);
        _kisiDal.Add(response);
        return ResponseModel<KisiModel>.Success(model, 200);
    }

    public ResponseModel<NoContentModel> CreateList(List<KisiModel> model)
    {
        var response = _mapper.Map<List<Kisi>>(model);
        _kisiDal.AddList(response);
        return ResponseModel<NoContentModel>.Success(204);
    }

    public ResponseModel<KisiModel> Update(int id, KisiModel model)
    {
        var response = _mapper.Map<Kisi>(model);
        _kisiDal.Update(id, response);
        return ResponseModel<KisiModel>.Success(model, 200);
    }

    public Task Delete(int id)
    {
        return _kisiDal.Delete(id);
    }
}