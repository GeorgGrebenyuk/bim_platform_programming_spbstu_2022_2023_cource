"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.4: Получение свойств помещений модели с привязкой к уровню
(логическое продолжение скрипта из лекции 3.3)
"""

import win32com.client
import json

def get_nodel_object_str_id(renga_one_model_object_input):
    return renga_one_model_object_input.ObjectTypeS.lower()

def get_objects_Properties(renga_model_object):
    props = dict()
    object_PropertyContainer = renga_model_object.GetProperties()
    object_properties_guids = object_PropertyContainer.GetIds()
    for one_guid_index in range(0, object_properties_guids.Count, 1):
        object_property_guid_s = object_properties_guids.GetS(one_guid_index)
        object_Property = object_PropertyContainer.GetS(object_property_guid_s)
        props[object_Property.Name] = object_Property.GetStringValue()
    return props

def get_objects_Quantities(renga_model_object):
    props = dict()
    props_internal = {
        "NominalHeight": "{e8f1a615-3b0c-401c-ad1f-7526f2f073e2}",
        "GrossWallArea": "{4144973d-c4b7-4f11-ab48-8794c9beae43}",
        "GrossCeilingArea": "{3e5395c2-5f6b-4d58-8349-1419a29a47b9}",
        "NetPerimeter": "{3560988c-ca06-4028-a821-726bab038536}",
        "NetWallArea": "{c2975e1e-3293-4ad1-8136-316d191b75cc}",
        "NetCeilingArea": "{e6265c5c-7692-49bd-b7a1-0a5f452feedd}",
        "GrossPerimeter": "{eb5bd744-3c80-46a2-b491-2ca4f11dd13d}",
        "GrossFloorArea": "{89ab9b57-91b1-4f4a-9a45-9c935882231d}",
        "GrossVolume": "{da41f09a-0e02-40c7-9547-2a0f55b60078}",
        "RelativeObjectBottomElevation": "{e17d805b-0164-480a-849b-64fd022ec17a}",
        "RelativeObjectTopElevation": "{3ca98238-a2b5-424a-a579-6a0d66ef075a}"
    }
    object_QuantityContainer = renga_model_object.GetQuantities()
    for prop_name, prop_id in props_internal.items():
        renga_Quantity = object_QuantityContainer.GetS(prop_id)
        renga_quantity_type = renga_Quantity.Type
        match renga_quantity_type:
            case 1:
                props[prop_name] = str(renga_Quantity.AsCount())
            case 2:
                props[prop_name] = str(renga_Quantity.AsLength(4))
            case 3:
                props[prop_name] = str(renga_Quantity.AsArea(3))
            case 4:
                props[prop_name] = str(renga_Quantity.AsVolume(3))
            case 5:
                props[prop_name] = str(renga_Quantity.AsMass(2))
        print(props[prop_name])
    return props

renga_app = win32com.client.Dispatch("Renga.Application.1")
if renga_app is not None:
    renga_project = renga_app.Project
    if renga_project is not None:
        model_objects = renga_project.Model.GetObjects()

        #Сохранение информации об уровнях во временный словарь
        level_objects = dict()
        for one_model_object_index in range(0,model_objects.Count, 1):
            renga_one_model_object = model_objects.GetByIndex(one_model_object_index)
            if get_nodel_object_str_id(renga_one_model_object) == '{c3ce17ff-6f28-411f-b18d-74fe957b2ba8}':
                level_objects[renga_one_model_object.Id] = renga_one_model_object.Name

        #Перебор комнат
        rooms_data_list = dict()
        for one_model_object_index in range(0, model_objects.Count, 1):
            renga_one_model_object = model_objects.GetByIndex(one_model_object_index)
            if get_nodel_object_str_id(renga_one_model_object) == '{f1a805ff-573d-f46b-ffba-57f4bccaa6ed}':
                temp_room_dict = dict()
                level_object = renga_one_model_object.GetInterfaceByName("ILevelObject")
                if level_object is not None:
                    temp_room_dict["level_name"] = level_objects[level_object.LevelId]
                    temp_room_dict["properties"] = get_objects_Properties(renga_one_model_object)
                    temp_room_dict["quantites"] = get_objects_Quantities(renga_one_model_object)
                    rooms_data_list[renga_one_model_object.Id] = temp_room_dict
        with open(r'E:\Temp\renga_rooms_data.json', 'w') as f:
            json.dump(rooms_data_list, f, ensure_ascii=False, indent = 3)
    else:
        print("Project was not openned")
else:
    print("Invalid_connection")