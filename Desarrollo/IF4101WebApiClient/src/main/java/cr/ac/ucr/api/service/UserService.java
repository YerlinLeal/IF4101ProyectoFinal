package cr.ac.ucr.api.service;

import cr.ac.ucr.api.model.User;
import cr.ac.ucr.api.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
@Transactional
public class UserService {
    @Autowired
    private UserRepository repository;

    public List<User> listAll() {
        return repository.findAll();
    }

    public void save(User student) {
        repository.save(student);
    }

    public User get(int id) {
        return repository.findById(id).get();
    }

    public void delete(int id) {
        repository.deleteById(id);
    }
}
