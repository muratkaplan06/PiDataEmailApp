using AutoMapper;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Models;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.Entities;
using System.Net.Mail;

namespace PiDataEmailApp.Business.Concrete;

public class EpostaGonderimManager : IEpostaGonderimService
{
    private readonly IEpostaGonderimDal _epostaGonderimDal;
    private readonly IEpostaGonderimDetayDal _epostaGonderimDetayDal;
    private readonly IEpostaAdresiDal _epostaAdresiDal;
    private readonly IMapper _mapper;

    public EpostaGonderimManager(IEpostaGonderimDal epostaGonderimDal,
        IEpostaGonderimDetayDal epostaGonderimDetayDal,
        IEpostaAdresiDal epostaAdresiDal,
        IMapper mapper)
    {
        _epostaGonderimDal = epostaGonderimDal;
        _epostaGonderimDetayDal = epostaGonderimDetayDal;
        _epostaAdresiDal = epostaAdresiDal;
        _mapper = mapper;
    }
    public async Task<ResponseModel<List<EpostaGonderimModel>>> GetAll()
    {
        var response = await _epostaGonderimDal.GetAll();
        var result = _mapper.Map<List<EpostaGonderimModel>>(response);
        return await ResponseModel<List<EpostaGonderimModel>>.SuccessAsync(result, 200);

    }

    public ResponseModel<EpostaGonderimModel> GetById(int id)
    {
        var response = _epostaGonderimDal.GetById(id);
        var result = _mapper.Map<EpostaGonderimModel>(response);
        return ResponseModel<EpostaGonderimModel>.Success(result, 200);
    }

    public async Task<ResponseModel<EpostaGonderimModel>> Create(EpostaGonderimModel model)
    {
        var gonderenEmailId = Guid.NewGuid();
        int epostaAdresiId =_epostaAdresiDal.Get(x => x.Adres == model.GonderenEmail)!.Id;
        EpostaGonderim epostaGonderim = new EpostaGonderim
        {
            Id=gonderenEmailId,
            Konusu = model.Konu,
            Icerigi = model.Icerik,
            GonderenEpostaAdresi = model.GonderenEmail,
            EpostaAdresiId = epostaAdresiId
        };
        await _epostaGonderimDal.Add(epostaGonderim);
        
        foreach (var id in model.KisiListesiIds)
        {
            EpostaGonderimDetayModel epostaGonderimDetayModel = new EpostaGonderimDetayModel
            {
                EpostaGonderimId =gonderenEmailId,
                KisiId = id,
                GonderimDurumu = true,
                GonderimTarihi = DateTime.UtcNow
                
            };
            var epostaGonderimDetay = _mapper.Map<EpostaGonderimDetay>(epostaGonderimDetayModel);
            await _epostaGonderimDetayDal.Add(epostaGonderimDetay);
        }

        return await ResponseModel<EpostaGonderimModel>.SuccessAsync(model, 200);
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

