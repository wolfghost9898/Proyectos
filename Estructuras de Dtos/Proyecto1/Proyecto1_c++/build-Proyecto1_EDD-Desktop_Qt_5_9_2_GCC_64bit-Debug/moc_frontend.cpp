/****************************************************************************
** Meta object code from reading C++ file 'frontend.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.9.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../Proyecto1_EDD/frontend.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'frontend.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.9.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_FrontEnd_t {
    QByteArrayData data[9];
    char stringdata0[91];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_FrontEnd_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_FrontEnd_t qt_meta_stringdata_FrontEnd = {
    {
QT_MOC_LITERAL(0, 0, 8), // "FrontEnd"
QT_MOC_LITERAL(1, 9, 12), // "obtenerDatos"
QT_MOC_LITERAL(2, 22, 0), // ""
QT_MOC_LITERAL(3, 23, 5), // "nivel"
QT_MOC_LITERAL(4, 29, 7), // "tamanio"
QT_MOC_LITERAL(5, 37, 12), // "updatePixmap"
QT_MOC_LITERAL(6, 50, 11), // "updateTimer"
QT_MOC_LITERAL(7, 62, 14), // "on_Ver_clicked"
QT_MOC_LITERAL(8, 77, 13) // "cambiarTiempo"

    },
    "FrontEnd\0obtenerDatos\0\0nivel\0tamanio\0"
    "updatePixmap\0updateTimer\0on_Ver_clicked\0"
    "cambiarTiempo"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_FrontEnd[] = {

 // content:
       7,       // revision
       0,       // classname
       0,    0, // classinfo
       5,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    2,   39,    2, 0x08 /* Private */,
       5,    0,   44,    2, 0x08 /* Private */,
       6,    0,   45,    2, 0x08 /* Private */,
       7,    0,   46,    2, 0x08 /* Private */,
       8,    0,   47,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void, QMetaType::QString, QMetaType::QString,    3,    4,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,

       0        // eod
};

void FrontEnd::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        FrontEnd *_t = static_cast<FrontEnd *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->obtenerDatos((*reinterpret_cast< QString(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2]))); break;
        case 1: _t->updatePixmap(); break;
        case 2: _t->updateTimer(); break;
        case 3: _t->on_Ver_clicked(); break;
        case 4: _t->cambiarTiempo(); break;
        default: ;
        }
    }
}

const QMetaObject FrontEnd::staticMetaObject = {
    { &QMainWindow::staticMetaObject, qt_meta_stringdata_FrontEnd.data,
      qt_meta_data_FrontEnd,  qt_static_metacall, nullptr, nullptr}
};


const QMetaObject *FrontEnd::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *FrontEnd::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_FrontEnd.stringdata0))
        return static_cast<void*>(this);
    return QMainWindow::qt_metacast(_clname);
}

int FrontEnd::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QMainWindow::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 5)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 5;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 5)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 5;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
