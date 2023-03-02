"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.3: Разбор Renga API на примере получения центров геометрии помещений
"""
import win32com.client

def get_nodel_object_str_id(id):
    return renga_one_model_object.ObjectTypeS.lower()

def get_centroid_by_geometry(object_3d_geometry):
    points_temp = list()
    for one_mesh_index in range (0, object_3d_geometry.MeshCount,1):
        geometry_mesh = object_3d_geometry.GetMesh(one_mesh_index)
        for one_drid_index in range(0, geometry_mesh.GridCount,1):
            geometry_grid = geometry_mesh.GetGrid(one_drid_index)
            for one_vertex_index in range(0, geometry_grid.VertexCount, 1):
                renga_vertex = geometry_grid.GetVertex(one_vertex_index)
                points_temp.append([renga_vertex.X, renga_vertex.Y, renga_vertex.Z])
    #Получение центроида
    temp_points_count = len(points_temp)
    temp_out_point = [0.0,0.0,0.0]
    for point_index in range(0, temp_points_count, 1):
        current_point = points_temp[point_index]
        temp_out_point[0] += current_point [0]
        temp_out_point[1] += current_point[1]
        temp_out_point[2] += current_point[2]
    temp_out_point[0] = temp_out_point[0] / temp_points_count
    temp_out_point[1] = temp_out_point[1] / temp_points_count
    temp_out_point[2] = temp_out_point[2] / temp_points_count
    return temp_out_point

renga_app = win32com.client.Dispatch("Renga.Application.1")
if renga_app is not None:
    renga_project = renga_app.Project
    if renga_project is not None:
        model_objects = renga_project.Model.GetObjects()
        #Поиск нужного уровня
        modeL_object_needing_elevation_id = 0
        for one_model_object_index in range(0,model_objects.Count, 1):
            renga_one_model_object = model_objects.GetByIndex(one_model_object_index)
            if get_nodel_object_str_id(renga_one_model_object) == '{c3ce17ff-6f28-411f-b18d-74fe957b2ba8}' \
                    and renga_one_model_object.Name == "+27,000 - 10":
                modeL_object_needing_elevation_id = renga_one_model_object.Id
                break
            else:
                continue
        print("Найденный уровень, идентфикатор = " + str(modeL_object_needing_elevation_id))
        #Получение комнат
        renga_data_exporter = renga_project.DataExporter
        renga_3d_objects = renga_data_exporter.GetObjects3D()
        def get_3d_model_object(model_id):
            for one_3d_object_index in range(0, renga_3d_objects.Count, 1):
                renga_3d_object = renga_3d_objects.Get(one_3d_object_index)
                if renga_3d_object.ModelObjectId == model_id:
                    return get_centroid_by_geometry(renga_3d_object)
            pass
        for one_model_object_index in range(0, model_objects.Count, 1):
            renga_one_model_object = model_objects.GetByIndex(one_model_object_index)
            if get_nodel_object_str_id(renga_one_model_object) == '{f1a805ff-573d-f46b-ffba-57f4bccaa6ed}':
                level_object = renga_one_model_object.GetInterfaceByName("ILevelObject")
                if level_object is not None:
                    if level_object.LevelId == modeL_object_needing_elevation_id:
                        print("Добавлена комната " + str(renga_one_model_object.Id) + " " + renga_one_model_object.Name)
                        geometry_room = get_3d_model_object(renga_one_model_object.Id)
                        print("Rooms' centroid = " + "X = " + str(geometry_room[0]) + "Y = " + str(geometry_room[1]) +
                              "Z = " + str(geometry_room[2]))
    else:
        print("Project was not openned")
else:
    print("Invalid_connection")