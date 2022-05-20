class Event(object):
    
    def __init__(self, doc=None):
        self.__doc__ = doc
    
    def __get__(self, obj, objtype=None):
        if obj is None:
            return self
        return EventHandler(self, obj)
    
    def __set__(self, obj, value):
        pass


class EventHandler(object):
    
    def __init__(self, event, obj):
        
        self.event = event
        self.obj = obj
    
    def _getfunctionlist(self):
        
        """(internal use) """
        
        try:
            eventhandler = self.obj.__eventhandler__
        except AttributeError:
            eventhandler = self.obj.__eventhandler__ = {}
        return eventhandler.setdefault(self.event, [])
    
    def add(self, func):
        
        """Add new event handler function.
        
        Event handler function must be defined like func(sender, earg).
        You can add handler also by using '+=' operator.
        """
        
        self._getfunctionlist().append(func)
        return self
    
    def remove(self, func):
        
        """Remove existing event handler function.
        
        You can remove handler also by using '-=' operator.
        """
        
        self._getfunctionlist().remove(func)
        return self
    
    def fire(self, earg=None):
        
        """Fire event and call all handler functions
        
        You can call EventHandler object itself like e(earg) instead of 
        e.fire(earg).
        """
        
        for func in self._getfunctionlist():
            func(self.obj, earg)
    
    __iadd__ = add
    __isub__ = remove
    __call__ = fire

import mEvent


class Publisher(object):
    
    # Set event object in class declaration.
    evt_foo = mEvent.Event('here comes foo')
    
    def foo(self,earg):
        # Do some actions and fire event.
        self.evt_foo(earg)


# Event handler may be a function or a instance method etc.
# Every handler must accept two arguments; a sender and an event-specific 
# parameter.
def handle_foo(sender, earg):
    print (earg[0])


if __name__ == '__main__':
    
    pub = Publisher()
    # Add event handler
    pub.evt_foo += handle_foo
    # This will cause Publiser.evt_foo event.
    pub.foo(["fooooooooooooooooooooooooooooooooooooooooooooo!!!",""])