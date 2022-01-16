// generated from rosidl_generator_cpp/resource/idl__struct.hpp.em
// with input from girbal_msgs:msg/StateArray.idl
// generated code does not contain a copyright notice

#ifndef GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_HPP_
#define GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_HPP_

#include <rosidl_runtime_cpp/bounded_vector.hpp>
#include <rosidl_runtime_cpp/message_initialization.hpp>
#include <algorithm>
#include <array>
#include <memory>
#include <string>
#include <vector>


#ifndef _WIN32
# define DEPRECATED__girbal_msgs__msg__StateArray __attribute__((deprecated))
#else
# define DEPRECATED__girbal_msgs__msg__StateArray __declspec(deprecated)
#endif

namespace girbal_msgs
{

namespace msg
{

// message struct
template<class ContainerAllocator>
struct StateArray_
{
  using Type = StateArray_<ContainerAllocator>;

  explicit StateArray_(rosidl_runtime_cpp::MessageInitialization _init = rosidl_runtime_cpp::MessageInitialization::ALL)
  {
    if (rosidl_runtime_cpp::MessageInitialization::ALL == _init ||
      rosidl_runtime_cpp::MessageInitialization::ZERO == _init)
    {
      this->angry = 0l;
    }
  }

  explicit StateArray_(const ContainerAllocator & _alloc, rosidl_runtime_cpp::MessageInitialization _init = rosidl_runtime_cpp::MessageInitialization::ALL)
  {
    (void)_alloc;
    if (rosidl_runtime_cpp::MessageInitialization::ALL == _init ||
      rosidl_runtime_cpp::MessageInitialization::ZERO == _init)
    {
      this->angry = 0l;
    }
  }

  // field types and members
  using _states_type =
    std::vector<int32_t, typename ContainerAllocator::template rebind<int32_t>::other>;
  _states_type states;
  using _angry_type =
    int32_t;
  _angry_type angry;

  // setters for named parameter idiom
  Type & set__states(
    const std::vector<int32_t, typename ContainerAllocator::template rebind<int32_t>::other> & _arg)
  {
    this->states = _arg;
    return *this;
  }
  Type & set__angry(
    const int32_t & _arg)
  {
    this->angry = _arg;
    return *this;
  }

  // constant declarations

  // pointer types
  using RawPtr =
    girbal_msgs::msg::StateArray_<ContainerAllocator> *;
  using ConstRawPtr =
    const girbal_msgs::msg::StateArray_<ContainerAllocator> *;
  using SharedPtr =
    std::shared_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator>>;
  using ConstSharedPtr =
    std::shared_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator> const>;

  template<typename Deleter = std::default_delete<
      girbal_msgs::msg::StateArray_<ContainerAllocator>>>
  using UniquePtrWithDeleter =
    std::unique_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator>, Deleter>;

  using UniquePtr = UniquePtrWithDeleter<>;

  template<typename Deleter = std::default_delete<
      girbal_msgs::msg::StateArray_<ContainerAllocator>>>
  using ConstUniquePtrWithDeleter =
    std::unique_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator> const, Deleter>;
  using ConstUniquePtr = ConstUniquePtrWithDeleter<>;

  using WeakPtr =
    std::weak_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator>>;
  using ConstWeakPtr =
    std::weak_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator> const>;

  // pointer types similar to ROS 1, use SharedPtr / ConstSharedPtr instead
  // NOTE: Can't use 'using' here because GNU C++ can't parse attributes properly
  typedef DEPRECATED__girbal_msgs__msg__StateArray
    std::shared_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator>>
    Ptr;
  typedef DEPRECATED__girbal_msgs__msg__StateArray
    std::shared_ptr<girbal_msgs::msg::StateArray_<ContainerAllocator> const>
    ConstPtr;

  // comparison operators
  bool operator==(const StateArray_ & other) const
  {
    if (this->states != other.states) {
      return false;
    }
    if (this->angry != other.angry) {
      return false;
    }
    return true;
  }
  bool operator!=(const StateArray_ & other) const
  {
    return !this->operator==(other);
  }
};  // struct StateArray_

// alias to use template instance with default allocator
using StateArray =
  girbal_msgs::msg::StateArray_<std::allocator<void>>;

// constant definitions

}  // namespace msg

}  // namespace girbal_msgs

#endif  // GIRBAL_MSGS__MSG__DETAIL__STATE_ARRAY__STRUCT_HPP_
