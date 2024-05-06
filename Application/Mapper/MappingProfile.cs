using AutoMapper;
using Domain;
using MySpace.Application.User;
using MySpace.Application.Category;
using MySpace.Application.Space;
using MySpace.Application.Note;
using MySpace.Application.Member;
using MySpace.Application.Files;
using Domain.enums;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User

        CreateMap<CreateUserRequest, Domain.User>();

        CreateMap<Domain.User, CreateUserResponse>();

        CreateMap<EditUserRequest, Domain.User>();
        CreateMap<Domain.User, EditUserResponse>();

        CreateMap<DeleteUserRequest, Domain.User>();
        CreateMap<Domain.User, DeleteUserResponse>();

        CreateMap<GetUserByIdRequest, Domain.User>();
        CreateMap<Domain.User, GetUserByIdResponse>();

        CreateMap<GetAllUsersRequest,Domain.User > ();
        CreateMap<Domain.User, GetAllUsersResponse>();

        #endregion

        #region Category

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();

        CreateMap<EditCategoryRequest, Category>();
        CreateMap<Category, EditCategoryResponse>();

        CreateMap<DeleteCategoryRequest, Category>();
        CreateMap<Category, DeleteCategoryResponse>();

        CreateMap<GetByIdRequest, Category > ();
        CreateMap<Category, GetByIdResponse>();
       //.ForMember(dest => dest.Space, opt => opt.MapFrom(src => src.Space)); 

        CreateMap<GetAllCategoriesRequest, Category>();
        CreateMap<Category, GetAllCategoriesResponse>();

        #endregion

        #region Space
        CreateMap<CreateSpaceRequest, Domain.Space>()
            .ForMember(c => c.Categories, option => option.Ignore())
            .ForMember(c => c.Members, option => option.Ignore());
        CreateMap<Domain.Space, CreateSpaceResponse>();

        CreateMap<EditSpaceRequest, Domain.Space>();
        CreateMap<Domain.Space, EditSpaceResponse>();

        CreateMap<DeleteSpaceRequest, Domain.Space>();
        CreateMap<Domain.Space, DeleteSpaceResponse>();

        CreateMap<GetAllSpacesRequest, Domain.Space>();
        CreateMap<Domain.Space, GetAllSpacesResponse>();

        CreateMap<GetSpaceByIdRequest, Domain.Space>();
        CreateMap<Domain.Space, GetSpaceByIdResponse>();


        #endregion 

        #region Note

        CreateMap<CreateNoteRequest, Domain.Note>();
        CreateMap<Domain.Note, CreateNoteResponse>();
            //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category));

        CreateMap<EditNoteRequest, Domain.Note>();
        CreateMap<Domain.Note, EditNoteResponse>();
        
        CreateMap<DeleteNoteRequest, Domain.Note>();
        CreateMap<Domain.Note, DeleteNoteResponse>();

        CreateMap<GetNoteByIdRequest, Domain.Note>();
        CreateMap<Domain.Note, GetNoteByIdResponse>();

        CreateMap<GetAllNotesRequest, Domain.Note>();
        CreateMap<Domain.Note, GetAllNotesResponse>();

        #endregion

        #region member
        CreateMap<CreateMemberRequest, Domain.Member>()
       .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

        CreateMap<Domain.Member, CreateMemberResponse>();

        CreateMap<GetAllMembersRequest, Domain.Member>();
        CreateMap<Domain.Member, GetAllMembersResponse>();

        CreateMap<GetMemberByIdRequest, Domain.Member>();
        CreateMap<Domain.Member, GetMemberByIdResponse>();

        CreateMap<Role, ProtoKeyValuePair>().ConvertUsing(src => new ProtoKeyValuePair { Key = src.Value, Value = src.Name });
        CreateMap<int, Role>().ConstructUsing(src => Role.FromValue(src));
        #endregion




        CreateMap<CreatFile, Domain.File>();
        CreateMap<Domain.File, FileResponse>();

        CreateMap<FileById, Domain.File>();
        CreateMap<Domain.File, FileResponse>();


    }
}
