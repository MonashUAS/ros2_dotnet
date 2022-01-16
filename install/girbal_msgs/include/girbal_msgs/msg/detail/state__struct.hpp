// generated from rosidl_generator_cpp/resource/idl__struct.hpp.em
// with input from girbal_msgs:msg/State.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_HPP_

#include <rosidl_runtime_cpp/bounded_vector.hpp>
#include <rosidl_runtime_cpp/message_initialization.hpp>
#include <algorithm>
#include <array>
#include <memory>
#include <string>
#include <vector>


#ifndef _WIN32
# define DEPRECATED__girbal_msgs__msg__State __attribute__((deprecated))
#else
# define DEPRECATED__girbal_msgs__msg__State __declspec(deprecated)
#endif

namespace girbal_msgs
{

namespace msg
{

// message struct
template<class ContainerAllocator>
struct State_
{
  using Type = State_<ContainerAllocator>;

  explicit State_(rosidl_runtime_cpp::MessageInitialization _init = rosidl_runtime_cpp::MessageInitialization::ALL)
  {
    if (rosidl_runtime_cpp::MessageInitialization::ALL == _init ||
      rosidl_runtime_cpp::MessageInitialization::ZERO == _init)
    {
      this->x = 0l;
      this->y = 0l;
      this->t = 0ul;
      this->droneid = 0ul;
    }
  }

  explicit State_(const ContainerAllocator & _alloc, rosidl_runtime_cpp::MessageInitialization _init = rosidl_runtime_cpp::MessageInitialization::ALL)
  {
    (void)_alloc;
    if (rosidl_runtime_cpp::MessageInitialization::ALL == _init ||
      rosidl_runtime_cpp::MessageInitialization::ZERO == _init)
    {
      this->x = 0l;
      this->y = 0l;
      this->t = 0ul;
      this->droneid = 0ul;
    }
  }

  // field types and members
  using _x_type =
    int32_t;
  _x_type x;
  using _y_type =
    int32_t;
  _y_type y;
  using _t_type =
    uint32_t;
  _t_type t;
  using _droneid_type =
    uint32_t;
  _droneid_type droneid;

  // setters for named parameter idiom
  Type & set__x(
    const int32_t & _arg)
  {
    this->x = _arg;
    return *this;
  }
  Type & set__y(
    const int32_t & _arg)
  {
    this->y = _arg;
    return *this;
  }
  Type & set__t(
    const uint32_t & _arg)
  {
    this->t = _arg;
    return *this;
  }
  Type & set__droneid(
    const uint32_t & _arg)
  {
    this->droneid = _arg;
    return *this;
  }

  // constant declarations

  // pointer types
  using RawPtr =
    girbal_msgs::msg::State_<ContainerAllocator> *;
  using ConstRawPtr =
    const girbal_msgs::msg::State_<ContainerAllocator> *;
  using SharedPtr =
    std::shared_ptr<girbal_msgs::msg::State_<ContainerAllocator>>;
  using ConstSharedPtr =
    std::shared_ptr<girbal_msgs::msg::State_<ContainerAllocator> const>;

  template<typename Deleter = std::default_delete<
      girbal_msgs::msg::State_<ContainerAllocator>>>
  using UniquePtrWithDeleter =
    std::unique_ptr<girbal_msgs::msg::State_<ContainerAllocator>, Deleter>;

  using UniquePtr = UniquePtrWithDeleter<>;

  template<typename Deleter = std::default_delete<
      girbal_msgs::msg::State_<ContainerAllocator>>>
  using ConstUniquePtrWithDeleter =
    std::unique_ptr<girbal_msgs::msg::State_<ContainerAllocator> const, Deleter>;
  using ConstUniquePtr = ConstUniquePtrWithDeleter<>;

  using WeakPtr =
    std::weak_ptr<girbal_msgs::msg::State_<ContainerAllocator>>;
  using ConstWeakPtr =
    std::weak_ptr<girbal_msgs::msg::State_<ContainerAllocator> const>;

  // pointer types similar to ROS 1, use SharedPtr / ConstSharedPtr instead
  // NOTE: Can't use 'using' here because GNU C++ can't parse attributes properly
  typedef DEPRECATED__girbal_msgs__msg__State
    std::shared_ptr<girbal_msgs::msg::State_<ContainerAllocator>>
    Ptr;
  typedef DEPRECATED__girbal_msgs__msg__State
    std::shared_ptr<girbal_msgs::msg::State_<ContainerAllocator> const>
    ConstPtr;

  // comparison operators
  bool operator==(const State_ & other) const
  {
    if (this->x != other.x) {
      return false;
    }
    if (this->y != other.y) {
      return false;
    }
    if (this->t != other.t) {
      return false;
    }
    if (this->droneid != other.droneid) {
      return false;
    }
    return true;
  }
  bool operator!=(const State_ & other) const
  {
    return !this->operator==(other);
  }
};  // struct State_

// alias to use template instance with default allocator
using State =
  girbal_msgs::msg::State_<std::allocator<void>>;

// constant definitions

}  // namespace msg

}  // namespace girbal_msgs

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE__STRUCT_HPP_
