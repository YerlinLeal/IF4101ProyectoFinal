package cr.ac.ucr.api.service;


import cr.ac.ucr.api.model.Issue;
import cr.ac.ucr.api.repository.IssuesRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
@Transactional
public class IssueService {
    @Autowired
    private IssuesRepository repository;

    public List<Issue> listAll() {
        return repository.findAll();
    }

    public void save(Issue issue) {
        repository.save(issue);
    }

    public Issue get(int id) {
        return repository.findById(id).get();
    }

    public void delete(int id) {
        repository.deleteById(id);
    }

}
